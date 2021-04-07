using JsonDiffPatchDotNet;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Entities.Base;
using FinoSabor.Infra.CrossCutting.Identity.Extensions;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data
{
    public static class LoggingContext
    {
        private static readonly List<EntityState> entityStates = new List<EntityState>() { EntityState.Added, EntityState.Modified, EntityState.Deleted };

        public static async Task LogChanges(this FinoSaborContext context, IAspNetUser appuser)
        {
            //var logTime = DateTime.Now;
            const string emptyJson = "{}";
            const string idColumn = "id";

            Guid? user = null;
            if (!string.IsNullOrEmpty(appuser.ObterUserId().ToString()))
                user = appuser.ObterUserId();

            var changes = context.ChangeTracker.Entries()
                .Where(x => entityStates.Contains(x.State) && x.Entity.GetType().IsSubclassOf(typeof(EntityBase)))
                .ToList();

            var jdp = new JsonDiffPatch();

            foreach (var item in changes)
            {
                var original = emptyJson;
                var updated = JsonConvert.SerializeObject(item.CurrentValues.Properties.ToDictionary(pn => pn.Name, pn => item.CurrentValues[pn]));
                var creationDate = DateTime.Now;

                if (item.State == EntityState.Modified)
                {
                    var dbValues = await item.GetDatabaseValuesAsync();

                    if (dbValues != null)
                    {
                        original = JsonConvert.SerializeObject(dbValues.Properties.ToDictionary(pn => pn.Name, pn => dbValues[pn]));
                        //creationDate = dbValues.GetValue<DateTime>("DataCadastro");
                    }
                }

                //item.Property("DataCadastro").CurrentValue = creationDate;

                string jsonDiff = jdp.Diff(original, updated);

                if (string.IsNullOrWhiteSpace(jsonDiff) == false)
                {
                    var EntityDiff = JToken.Parse(jsonDiff).ToString(Formatting.None);

                    var log = new Log()
                    {
                        nome_entidade = item.Entity.GetType().Name,
                        id_entidade = new Guid(item.CurrentValues[idColumn].ToString()),
                        //LogDateTime = logTime,
                        operacao = item.State.ToString(),
                        id_usuario = user,
                        valores_alterados = EntityDiff,
                    };

                    context.log.Add(log);
                }

            }
        }
    }
}
