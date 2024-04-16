namespace FoodComposition.Communication
{
    public class FoodCompositionItem
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string NameFood { get; set; }

        public string? ScientificName { get; set; }

        public string GroupFood { get; set; }

        public List<string>? Componentes { get; set; }
    }
}