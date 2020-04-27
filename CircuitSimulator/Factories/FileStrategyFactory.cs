using CircuitSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Factories
{
    public class FileStrategyFactory
    {
        private static FileStrategyFactory instance = null;

        public static FileStrategyFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileStrategyFactory();
                }
                return instance;
            }
        }

        private FileStrategyFactory() 
        {
            Strategies = new Dictionary<string, IFileStrategy>();
        }

        private readonly Dictionary<string, IFileStrategy> Strategies;

        public void RegisterStrategy(string ext, IFileStrategy strategy)
        {
            if (ext == null || ext == string.Empty || strategy == null)
            {
                throw new ArgumentException();
            }    
            Strategies.Add(ext, strategy);
        }

        public IFileStrategy GetStrategy(string ext)
        {
            if(Strategies.ContainsKey(ext))
            {
                return Strategies[ext];
            }
            return null;
        }
    }
}