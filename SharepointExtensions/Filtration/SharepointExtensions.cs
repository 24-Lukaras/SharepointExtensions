using Microsoft.Graph.Models;
using Microsoft.Graph;

namespace SharepointExtensions.Filtration
{
    public static partial class SharepointExtensions
    {
        /// <summary>
        /// extension method for list item retreival using SharepointExtensions filters
        /// </summary>
        /// <param name="client"></param>
        /// <param name="siteId">id of sharepoint site</param>
        /// <param name="listId">id of sharepoint list</param>
        /// <param name="filter">instance of IFilterString used as a $filter query parameter</param>
        /// <param name="allowDangerous">allows to filter non-indexed fields</param>
        /// <param name="expandFields">indicates if response should also fetch all field values, default true</param>
        /// <returns>collection of list items</returns>
        public async static Task<IEnumerable<ListItem>> GetListItems(this GraphServiceClient client, string siteId, string listId, IFilterString filter, bool allowDangerous = false, bool expandFields = true)
        {
            var items = await client.Sites[siteId].Lists[listId]
                .Items
                .GetAsync(config =>
                {
                    if (allowDangerous)
                    {
                        config.Headers.Add("Prefer", "HonorNonIndexedQueriesWarningMayFailRandomly");
                    }
                    if (expandFields)
                    {
                        config.QueryParameters.Expand = ["fields"];
                    }
                    config.QueryParameters.Filter = filter.GetFilterString();
                });

            return items.Value;
        }
    }
}
