using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Model
{
    [Flags]
    public enum BookGenre
    {
        ScienceFiction = 1,
        Satire = 2,
        Drama = 4,
        ActionAdventure = 8,
        Romance = 16,
        Mystery = 32,
        Horror = 64,
        SelfHelp = 128,
        Health = 256,
        Guide = 512,
        Travel = 1024,
        Childrens = 2048,
        Religion = 4096,
        Science = 8192,
        History = 16384,
        Math = 32768,
        Poetry = 65536,
        Encyclopedias = 131072,
        Dictionaries = 262144,
        Comics = 524288,
        Art = 1048576,
        Cookbooks = 2097152,
        Diaries = 4194304,
        Journals = 8388608,
        Series = 16777216,
        Biographies = 33554432,
        Fantasy = 67108864
    }
}
