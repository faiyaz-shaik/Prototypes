using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ndpdata.Models.DataClasses
{
    public class Node
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public List<Node> Chidren{ get; set; }

        public Node Parent { get; set; }
    }
}