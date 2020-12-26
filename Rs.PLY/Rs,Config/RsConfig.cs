using System;

namespace Rs.Config
{
    [Serializable]
    public class RsConfig
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConnectionStringFull { get; set; }
        public string ApplicationPath { get; set; }
    }
}
