namespace restApiAnkiety
{
    public class OdpowiedzDto
    {
        public string Forma { get; set; }
        public List<string> Czestosc { get; set; } = new();
        public List<string> Tematyka { get; set; } = new();
    }

}
