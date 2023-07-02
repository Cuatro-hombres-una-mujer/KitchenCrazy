using System.Collections.Generic;

namespace Food
{
    public class PreparationStorage
    {

        private readonly IDictionary<string, Preparation> _preparations;

        public PreparationStorage()
        {
            _preparations = new Dictionary<string, Preparation>();
        }

        public void Register(Preparation preparation)
        {
            var item = preparation.Item;

            if (item != null)
            {
                _preparations.Add(item.Name, preparation);    
            }
            else
            {
                
            }
            
        }

        public Preparation Get(string name)
        {
            return _preparations[name];
        }
        
    }
    
}