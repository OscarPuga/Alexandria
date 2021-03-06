namespace Alexandria.Client.Consumers
{
    using Infrastructure;
    using Messages;
    using Rhino.ServiceBus;

    public class SearchResponseConsumer : ConsumerOf<SearchResponse>
    {
        private readonly ApplicationModel applicationModel;

        public SearchResponseConsumer(ApplicationModel applicationModel)
        {
            this.applicationModel = applicationModel;
        }

        public void Consume(SearchResponse message)
        {
            applicationModel.Search.Results.UpdateFrom(message.Books);
            applicationModel.Search.IsSearching = false;
            applicationModel.PotentialBooks = applicationModel.Search;
        }
    }
}