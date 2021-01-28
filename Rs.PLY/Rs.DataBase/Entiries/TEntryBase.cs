using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.DataBase
{
    [Serializable]
    public abstract class TEntryBase
    {
        /// <summary>
        /// 唯一标识号
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 数据添加时间
        /// </summary>
        public DateTime AddTime { get; set; } = DateTime.Now;
    }
}
