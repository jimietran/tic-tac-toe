using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe.Data
{
    /// <summary>
    /// Game data object
    /// </summary>
    public class GameObject
    {
        public int ID { get; set; }
        public string topLeft { get; set; }
        public string topMiddle { get; set; }
        public string topRight { get; set; }
        public string centerLeft { get; set; }
        public string centerMiddle { get; set; }
        public string centerRight { get; set; }
        public string bottomLeft { get; set; }
        public string bottomMiddle { get; set; }
        public string bottomRight { get; set; }

        public GameObject()
        {
        }
    }
}