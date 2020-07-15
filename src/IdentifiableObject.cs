using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task5_1
{
    public class IdentifiableObject
    {

        /*--------------------------------------------------------------------------------*/
        private List<string> _identifiers = new List<string>();
        /*--------------------------------------------------------------------------------*/

        public IdentifiableObject(string[] idents)
        {
            foreach (string ident in idents)
            {
                AddIdentifier(ident);
            }
        }


        public bool AreYou(string id) //performs check on id
        {
            foreach (string idents in _identifiers)
            {
                if (idents == id.ToLower())
                    return true;
            }
            return false;
        }

        public string FirstId
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }

                else
                {
                    return string.Empty;
                }
            }

        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
