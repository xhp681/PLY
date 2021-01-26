using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rs.Config
{
    /// <summary>
    /// 定义系统配置文件
    /// </summary>
    [Serializable]
    public class RsConfig
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConnectionStringFull { get; set; }
        public string ApplicationPath { get; set; }
    }
}
