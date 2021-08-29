using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.Helpers.Misc
{
    public static class MiscArr
    {
        public static string GetArrMap(JobName job)
        {
            return ArrMapStrings[GetJobIndex(job)];
        }
        public static PointF GetArrBrokenLocation(JobName job)
        {
            return ArrBrokenLocations[GetJobIndex(job)];
        }
        public static string GetArrRelicMat(JobName job)
        {
            return ArrRelicMats[GetJobIndex(job)];
        }
        public static string GetArrRelicMateria(JobName job)
        {
            return ArrRelicMaterias[GetJobIndex(job)];
        }
        public static List<string> GetArrBeastmen(JobName job)
        {
            return ArrRelicBeastmen[GetJobIndex(job)];
        }
        
        public static string GetArrRelicName(JobName job)
        {
            return ArrRelicWeaponNames[GetJobIndex(job)];
        }
        public static string GetArrZodiacName(JobName job)
        {
            return ArrZodiacWeaponNames[GetJobIndex(job)];
        }

        private static int GetJobIndex(JobName job)
        {
            return JobsByExpansion.ArrJobs.IndexOf(job)-1;
        }

        private static readonly List<string> ArrMapStrings = new List<string>()
        {
            "Images/SouthernThanalan.png",
            "Images/OuterLaNoscea.png",
            "Images/OuterLaNoscea.png",
            "Images/WesternLaNoscea.png",
            "Images/SouthernThanalan.png",
            "Images/CoerthasCentralHighlands.png",
            "Images/WesternLaNoscea.png",
            "Images/CoerthasCentralHighlands.png",
            "Images/OuterLaNoscea.png",
            "Images/EastShroud.png"
        };
        private static readonly List<PointF> ArrBrokenLocations = new List<PointF>()
        {
            new PointF(30F,19F),
            new PointF(23F,10F),
            new PointF(24.3F,6.4F),
            new PointF(16F, 17F),
            new PointF(32F, 18F),
            new PointF(34F, 21F),
            new PointF(16F, 17F),
            new PointF(34F, 21F),
            new PointF(23F, 10F),
            new PointF(25F, 19F)
        };

        private static readonly List<string> ArrRelicMats = new List<string>()
        {
           "Aeolian Scimitar",
           "Barbarian's Bardiche",
           "Madman's Whispering Rod",
           "Erudite's Picatrix of Healing",
           "Wildling's Cesti",
           "Champion's Lance",
           "Vamper's Knives",
           "Longarm's Composite Bow",
           "Sanguine Scepter",
           "Erudite's Picatrix of Casting"
        };

        private static readonly List<string> ArrRelicMaterias = new List<string>
        {
            "Battle Dance Materia III",
            "Battle Dance Materia III",
            "Quicktongue Materia III",
            "Quicktongue Materia III",
            "Savage Aim Materia III",
            "Savage Aim Materia III",
            "Heavens Eye Materia III",
            "Heavens Eye Materia III",
            "Savage Might Materia III",
            "Savage Might Materia III"
        };

        private static readonly List<List<string>> ArrRelicBeastmen =new List<List<string>>
        {
             new List<string>{"Zahar'ak Lance","Zahar'ak Pugliest","Zahar'ak Archer" },
             new List<string>{"13th Order Quarryman","13th Order Bedesman","13th Order Priest" },
             new List<string>{"13th Order Quarryman","13th Order Bedesman","13th Order Priest"},
             new List<string>{"Sapsa Shelfspine","Sapsa Shelfclaw", "Sapsa Shelftooth"},
             new List<string>{"Zahar'ak Lance","Zahar'ak Pugliest","Zahar'ak Archer" },
             new List<string>{"Natalan Boldwing","Natalan Fogcaller","Natalan Windtalon"},
             new List<string>{"Sapsa Shelfspine","Sapsa Shelfclaw", "Sapsa Shelftooth"},
             new List<string>{"Natalan Boldwing","Natalan Fogcaller","Natalan Windtalon"},
             new List<string>{"13th Order Quarryman","13th Order Bedesman","13th Order Priest"},
             new List<string>{"Violet Sigh", "Violet Screech","Violet Snarl"} 
        };
        private static readonly List<string> ArrRelicWeaponNames = new List<string>
        {
            "Curtana",
            "Bravura",
            "Thyrus",
            "Omnilex",
            "Sphairai",
            "Gae Bolg",
            "Yoshimitsu",
            "Artemis Bow",
            "Stardust Rod",
            "The Veil of Wiyu"
            
        };
        private static readonly List<string> ArrZodiacWeaponNames = new List<string>
        {
            "Excalibur",
            "Ragnarok",
            "Nirvana",
            "Last Resort",
            "Kaiser Knuckles",
            "Longinus",
            "Sasuke's Blades",
            "Yoichi Bow",
            "Lillith Rod",
            "Apocalypse"
            
        };

        #region Animus

        public static List<MapItem> ReturnCreatures(AnimusBookNames bookName)
        {
            List<string> tempNames = ReturnCreatureNames(bookName);
            List<ArrMapNames> tempMaps = ReturnCreatureMaps(bookName);
            List<PointF> tempPoints = ReturnCreaturePoints(bookName);

            List<MapItem> returnList = new List<MapItem>();

            for (int i = 0; i < tempMaps.Count; i++)
            {
                returnList.Add(new MapItem() { MapType = MapType.Creature, DisplayName = tempNames[i], ArrMapName = tempMaps[i], PointF = tempPoints[i] });
            }
            return returnList;
        }
        public static List<MapItem> ReturnFATEs(AnimusBookNames bookName)
        {
            List<string> tempNames = ReturnFATENames(bookName);
            List<ArrMapNames> tempMaps = ReturnFATEMaps(bookName);
            List<PointF> tempPoints = ReturnFATEPoints(bookName);

            List<MapItem> returnList = new List<MapItem>();

            for (int i = 0; i < tempMaps.Count; i++)
            {
                returnList.Add(new MapItem() { MapType = MapType.FATE, DisplayName = tempNames[i], ArrMapName = tempMaps[i], PointF = tempPoints[i] });
            }
            return returnList;
        }
        public static List<MapItem> ReturnLeves(AnimusBookNames bookName)
        {
            List<string> tempNames = ReturnLeveNames(bookName);
            List<string> tempTypes = ReturnLeveTypes(bookName);
            List<string> tempPersons = ReturnLevePersons(bookName);
            List<ArrMapNames> tempMaps = ReturnLeveLocations(bookName);
            List<PointF> tempPoints = ReturnLevePoints(bookName);

            List<MapItem> returnList = new List<MapItem>();

            for (int i = 0; i < tempMaps.Count; i++)
            {
                returnList.Add
                    (
                    new MapItem() 
                    { MapType = MapType.Leve, DisplayName = tempNames[i], ArrMapName = tempMaps[i], PointF = tempPoints[i], LevePerson=tempPersons[i], LeveType=tempTypes[i] }
                    );
            }
            return returnList;
        }
        public static List<string> ReturnBookDungeons(AnimusBookNames bookName) { return BookDungeons[(int)bookName]; }


        private static List<string> ReturnCreatureNames(AnimusBookNames bookName) { return BookCreatureNames[(int)bookName]; }
        private static List<ArrMapNames> ReturnCreatureMaps(AnimusBookNames bookName) { return BookCreatureMaps[(int)bookName]; }
        private static List<PointF> ReturnCreaturePoints(AnimusBookNames bookName) { return BookCreaturePoints[(int)bookName]; }


        private static List<string> ReturnFATENames(AnimusBookNames bookName) { return BookFATENames[(int)bookName]; }
        private static List<ArrMapNames> ReturnFATEMaps(AnimusBookNames bookName) { return BookFATEMaps[(int)bookName]; }
        private static List<PointF> ReturnFATEPoints(AnimusBookNames bookName) { return BookFATEPoints[(int)bookName]; }

        private static List<string> ReturnLeveNames(AnimusBookNames bookName) { return BookLeveNames[(int)bookName]; }
        private static List<string> ReturnLeveTypes(AnimusBookNames bookName) { return BookLeveTypes[(int)bookName]; }
        private static List<string> ReturnLevePersons(AnimusBookNames bookName) { return BookLevePersons[(int)bookName]; }
        private static List<ArrMapNames> ReturnLeveLocations(AnimusBookNames bookName) { return BookLeveLocations[(int)bookName]; }
        private static List<PointF> ReturnLevePoints(AnimusBookNames bookName) { return BookLevePoints[(int)bookName]; }


        private static readonly List<List<string>> BookCreatureNames = new List<List<string>>
        {
            new List<string>{"Daring Harrier","5th Cohort Vanguard","4th Cohort Hoplomachus","Basilisk","Zanr'ak Pugilist","Milkroot Cluster","Giant Logger","Synthetic Doblyn","Shoalspine Sahagin","2nd Cohort Hoplomachus"},
            new List<string>{"Raging Harrier","Biast","Natalan Boldwing","Shoaltooth Sahagin","Shelfscale Reaver","U'Ghamaro Golem","Dullahan","Sylpheed Sigh","Zahar'ak Archer","Tempered Gladiator"},
            new List<string>{"Hexing Harrier","Gigas Bonze","Giant Lugger","Wild Hog","Sylpheed Screech","U'Ghamaro Roundsman","Shelfclaw Reaver","2nd Cohort Laquearius","Zahar'ak Fortuneteller","Tempered Orator"},
            new List<string>{"Mudpuppy","Lake Cobra","Giant Reader","Shelfscale Shagin","Sea Wasp","U'Ghamarro Quarryman","2nd Cohort Eques","Magitek Vanguard","Amalj'aa Lancer","Sylphlands Sentinel"},
            new List<string>{"Gigas Bhikkhu","5th Cohort Hoplomachus","Natalan Watchwolf","Sylph Bonnet","Ked","4th Cohort Laquearius","Iron Tortoise","Shelfeye Reaver","Sapsa Shelfscale","U'Ghamaro Bedesman"},
            new List<string>{"Amalj'aa Brigand","4th Cohort Secutor","5th Cohort Laquearius","Gigas Sozu","Snow Wolf","Sapsa Shelfclaw","U'Ghamaro Priest","Violet Screech","Ixali Windtalon","Lesser Kalong"},
            new List<string>{"Hippogryph","5th Cohort Eques","Natalan Windtalon","Sapsa Elbst","Trenchtooth Sahagin","Elite Roundsman","2nd Cohort Secutores","Ahriman","Amalj'aa Thaumaturge","Sylpheed Snarl"},
            new List<string>{"Gigas Shramana","5th Cohort Signifer","Watchwolf","Dreamtoad","Zahar'ak Battle Drake","Amalj'aa Archer","4th Cohort Signifer","Elite Priest","Sapsa Shelftooth","Natalan Fogcaller"},
            new List<string>{"Violet Sigh","Ixali Boldwing","Amalj'aa Scavenger","Zahar'ak Pugilist","Axolotl","Elite Quarryman","2nd Cohort Signifer","Natalan Swiftbeak","5th Cohort Secutor","Hapalit"}
        };
        private static readonly List<List<ArrMapNames>> BookCreatureMaps = new List<List<ArrMapNames>>
        {
            new List<ArrMapNames>{ArrMapNames.MorDhona,ArrMapNames.MorDhona,ArrMapNames.WesternThanalan,ArrMapNames.NorthernThanalan,ArrMapNames.SouthernThanalan,ArrMapNames.EastShroud,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.OuterLaNoscea,ArrMapNames.WesternLaNoscea,ArrMapNames.EasternLaNoscea},
            new List<ArrMapNames>{ArrMapNames.MorDhona,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.WesternLaNoscea,ArrMapNames.WesternLaNoscea,ArrMapNames.OuterLaNoscea,ArrMapNames.NorthShroud,ArrMapNames.EastShroud,ArrMapNames.SouthernThanalan,ArrMapNames.SouthernThanalan},
            new List<ArrMapNames>{ArrMapNames.MorDhona,ArrMapNames.MorDhona,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.SouthShroud,ArrMapNames.EastShroud,ArrMapNames.OuterLaNoscea,ArrMapNames.WesternLaNoscea,ArrMapNames.EasternLaNoscea,ArrMapNames.SouthernThanalan,ArrMapNames.SouthernThanalan},
            new List<ArrMapNames>{ArrMapNames.MorDhona,ArrMapNames.MorDhona,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.WesternLaNoscea,ArrMapNames.WesternLaNoscea,ArrMapNames.OuterLaNoscea,ArrMapNames.EasternLaNoscea,ArrMapNames.NorthernThanalan,ArrMapNames.SouthernThanalan,ArrMapNames.EastShroud},
            new List<ArrMapNames>{ArrMapNames.MorDhona,ArrMapNames.MorDhona,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.EastShroud,ArrMapNames.SouthShroud,ArrMapNames.WesternThanalan,ArrMapNames.SouthernThanalan,ArrMapNames.WesternLaNoscea,ArrMapNames.WesternLaNoscea,ArrMapNames.OuterLaNoscea},
            new List<ArrMapNames>{ArrMapNames.SouthernThanalan,ArrMapNames.WesternThanalan,ArrMapNames.MorDhona,ArrMapNames.MorDhona,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.WesternLaNoscea,ArrMapNames.OuterLaNoscea,ArrMapNames.EastShroud,ArrMapNames.NorthShroud,ArrMapNames.NorthShroud},
            new List<ArrMapNames>{ArrMapNames.MorDhona,ArrMapNames.MorDhona,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.WesternLaNoscea,ArrMapNames.WesternLaNoscea,ArrMapNames.OuterLaNoscea,ArrMapNames.EasternLaNoscea,ArrMapNames.NorthernThanalan,ArrMapNames.SouthernThanalan,ArrMapNames.EastShroud},
            new List<ArrMapNames>{ArrMapNames.MorDhona,ArrMapNames.MorDhona,ArrMapNames.NorthShroud,ArrMapNames.EastShroud,ArrMapNames.SouthernThanalan,ArrMapNames.SouthernThanalan,ArrMapNames.WesternThanalan,ArrMapNames.OuterLaNoscea,ArrMapNames.WesternLaNoscea,ArrMapNames.CoerthasCentralHighlands},
            new List<ArrMapNames>{ArrMapNames.EastShroud,ArrMapNames.NorthShroud,ArrMapNames.SouthernThanalan,ArrMapNames.SouthernThanalan,ArrMapNames.WesternLaNoscea,ArrMapNames.OuterLaNoscea,ArrMapNames.EasternLaNoscea,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.MorDhona,ArrMapNames.MorDhona}
        };
        private static readonly List<List<PointF>> BookCreaturePoints = new List<List<PointF>>
        {
            new List<PointF>{new PointF(16.9F,16.4F),new PointF(10.6F,15.1F),new PointF(10.5F,6F),new PointF(22.8F,22.9F),new PointF(19F,25F),new PointF(23F,16F),new PointF(13F,25F),new PointF(23F,8F),new PointF(17F,15F),new PointF(25F,21F)},
            new List<PointF>{new PointF(17F,17F),new PointF(16F,30F),new PointF(33F,18F),new PointF(17F,17F),new PointF(13F,17F),new PointF(27.5F,7.3F),new PointF(22.5F,20F),new PointF(29F,17F),new PointF(25F,21F),new PointF(21.5F,19.6F)},
            new List<PointF>{new PointF(16F,15F),new PointF(27F,9F),new PointF(13F,27F),new PointF(29F,24F),new PointF(28F,15F),new PointF(23F,7F),new PointF(13F,17F),new PointF(29F,20F),new PointF(29F,19F),new PointF(21F,20F)}
            ,new List<PointF>{new PointF(14F,11F),new PointF(26F,12F),new PointF(12F,25F),new PointF(17F,19F),new PointF(14F,17F),new PointF(23F,7F),new PointF(29F,21F),new PointF(17F,17F),new PointF(20F,20F),new PointF(20F,10F)}
            ,new List<PointF>{new PointF(33F,14F),new PointF(12F,12F),new PointF(31F,17F),new PointF(26F,13F),new PointF(31F,23F),new PointF(10F,6F),new PointF(16F,24F),new PointF(13F,17F),new PointF(14F,14F),new PointF(23F,8F)}
            ,new List<PointF>{new PointF(20F,21F),new PointF(9F,6F),new PointF(12F,12F),new PointF(29F,14F),new PointF(13F,30F),new PointF(14F,15F),new PointF(22F,8F),new PointF(24F,14F),new PointF(19F,19F),new PointF(30F,25F)}
            ,new List<PointF>{new PointF(33F,11F),new PointF(12F,12F),new PointF(34F,22F),new PointF(17F,15F),new PointF(20F,19F),new PointF(25F,8F),new PointF(25F,21F),new PointF(24F,21F),new PointF(18F,19F),new PointF(28F,17F)}
            ,new List<PointF>{new PointF(28F,13F),new PointF(10F,13F),new PointF(19F,19F),new PointF(26F,18F),new PointF(30F,19F),new PointF(20F,22F),new PointF(11F,7F),new PointF(24F,7F),new PointF(15F,15F),new PointF(32F,18F)}
            ,new List<PointF>{new PointF(24F,13F),new PointF(21F,20F),new PointF(20F,21F),new PointF(23F,21F),new PointF(14F,15F),new PointF(24F,7F),new PointF(30F,20F),new PointF(31F,17F),new PointF(10F,13F),new PointF(30F,5F)}


        };

        private static readonly List<List<string>> BookDungeons = new List<List<string>>
        {
             new List<string>{"The Tam-Tara Deepcroft","The Stone Vigil","The Lost City of Amdapor"}
             ,new List<string>{"Brayflox's Longstop","The Wanderer's Palace","Copperbell Mines (Hard)"}
             ,new List<string>{"The Sunken Temple of Qarn","Haukke Manor (Hard)","Halatali (Hard)"}
             ,new List<string>{"Copperbell Mines","Dzemael Darkhold","Brayflox's Longstop (Hard)"}
             ,new List<string>{"The Thousand Maws of Toto-Rak","Amdapor Keep","Haukke Manor (Hard)"}
             ,new List<string>{"Cutter's Cry","Pharos Sirius","The Lost City of Amdapor"}
             ,new List<string>{"Sastasha","The Aurum Vale","Halatali (Hard)"}
             ,new List<string>{"Haukke Manor","Copperbell Mines (Hard)","Brayflox's Longstop (Hard)"}
             ,new List<string>{"Pharos Sirius","Halatali","Amdapor Keep"}
        };

        private static readonly List<List<string>> BookFATENames = new List<List<string>>
        {
            new List<string>{"Giant Seps","Make it Rain","The Enmity of My Enemy"},
            new List<string>{"Heroes of the 2nd","Breaching South Tidegate","Air Supply"},
            new List<string>{"Another Notch on the Torch","Everything's Better","Return to Cinder"},
            new List<string>{"Bellyful","The King's Justice","Quartz Coupling"},
            new List<string>{"Black and Nburu","Breaching North Tidegate","Breaking Dawn"},
            new List<string>{"Rude Awakening","The Ceruleum Road","The Four Winds"},
            new List<string>{"Surprise","In Spite of It All","Good to Be Bud"},
            new List<string>{"Taken","Tower of Power","What Gored Before"},
            new List<string>{"The Taste of Fear","The Big Bagoly Theory","Schism"}

        };
        private static readonly List<List<ArrMapNames>> BookFATEMaps = new List<List<ArrMapNames>>
        {
            new List<ArrMapNames>{ArrMapNames.CoerthasCentralHighlands,ArrMapNames.OuterLaNoscea,ArrMapNames.EastShroud},
            new List<ArrMapNames>{ArrMapNames.SouthernThanalan,ArrMapNames.WesternLaNoscea,ArrMapNames.NorthShroud},
            new List<ArrMapNames>{ArrMapNames.MorDhona,ArrMapNames.EastShroud,ArrMapNames.SouthernThanalan},
            new List<ArrMapNames>{ArrMapNames.CoerthasCentralHighlands,ArrMapNames.WesternLaNoscea,ArrMapNames.EasternThanalan},
            new List<ArrMapNames>{ArrMapNames.MorDhona,ArrMapNames.WesternLaNoscea,ArrMapNames.EastShroud},
            new List<ArrMapNames>{ArrMapNames.NorthShroud,ArrMapNames.NorthernThanalan,ArrMapNames.CoerthasCentralHighlands},
            new List<ArrMapNames>{ArrMapNames.UpperLaNoscea,ArrMapNames.CentralShroud,ArrMapNames.MorDhona},
            new List<ArrMapNames>{ArrMapNames.SouthernThanalan,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.SouthShroud},
            new List<ArrMapNames>{ArrMapNames.CoerthasCentralHighlands,ArrMapNames.EasternThanalan,ArrMapNames.OuterLaNoscea}

        };
        private static readonly List<List<PointF>> BookFATEPoints = new List<List<PointF>>
        {
            new List<PointF>{new PointF(8.6F,12F),new PointF(25F,18F),new PointF(27F,21.6F)},
            new List<PointF>{new PointF(21F,16F),new PointF(18F,22F),new PointF(19F,20F)},
            new List<PointF>{new PointF(31,y:5F),new PointF(23,y:14F),new PointF(24,y:26F)},
            new List<PointF>{new PointF(34F,14F),new PointF(14F,34F),new PointF(26F,24F)},
            new List<PointF>{new PointF(15F,13F),new PointF(21F,19F),new PointF(32F,14F)},
            new List<PointF>{new PointF(21,y:19F),new PointF(21,y:29F),new PointF(34,y:20F)},
            new List<PointF>{new PointF(26F,18F),new PointF(11F,18F),new PointF(13F,12F)},
            new List<PointF>{new PointF(18F,20F),new PointF(10F,28F),new PointF(32F,25F)},
            new List<PointF>{new PointF(4F,21F),new PointF(30F,25F),new PointF(25F,16F)}

        };

        private static readonly List<List<string>> BookLeveNames = new List<List<string>>
        {
            new List<string>{"Necrologos Pale Oblation","An Imp Mobile","The Awry Salvages"},
            new List<string>{"Don't Forget to Cry","Yellow Is the New Black","The Museum Is Closed"},
            new List<string>{"Circling the Ceruleum","If You Put It That Way","One Big Problem Solved"},
            new List<string>{"Circling the Ceruleum","Necrologos: Whispers of the Gem","Go Home to Mama"},
            new List<string>{"Someone's in the Doghouse","Get Off Our Lake","The Area's a Bit Sketchy"},
            new List<string>{"Got a Gut Feeling about This","Subduing the Subprime","Who Writes History"},
            new List<string>{"Subduing the Subprime","Someone's Got a Big Mouth","Big, Bad Idea"},
            new List<string>{"Necrologos: Pale Oblation","The Bloodhounds of Coerthas","Put Your Stomp on It"},
            new List<string>{"Don't Forget to Cry","Necrologos: The Liminal Ones","No Big Whoop"}

        };
        private static readonly List<List<string>> BookLeveTypes = new List<List<string>>
        {
            new List<string>{"General","Maelstrom Grand Company","Twin Adder Grand Company"},
            new List<string>{"General","Twin Adder Grand Company","Immortal Flames Grand Company"},
            new List<string>{"General","Immortal Flames Grand Company","Maelstrom Grand Company"},
            new List<string>{"General","General","Maelstrom Grand Company"},
            new List<string>{"General","Twin Adder Grand Company","General"},
            new List<string>{"General","General","Immortal Flames Grand Company"},
            new List<string>{"General","Maelstrom Grand Company","General"},
            new List<string>{"General","Twin Adder Grand Company","General"},
            new List<string>{"General","General","Immortal Flames Grand Company"}

        };
        private static readonly List<List<string>> BookLevePersons = new List<List<string>>
        {
            new List<string>{"Rurubana","Lodille","Eidhart"},
            new List<string>{"Rurubana","Lodille","Eidhart"},
            new List<string>{"Rurubana","Lodille","Eidhart"},
            new List<string>{"Rurubana","Voilinaut","Eidhart"},
            new List<string>{"Rurubana","Eidhart","Voilinaut"},
            new List<string>{"Voilinaut","Rurubana","Eidhart"},
            new List<string>{"Rurubana","Lodille","K'leytai"},
            new List<string>{"Rurubana","Lodille","K'leytai"},
            new List<string>{"Rurubana","K'leytai","Lodille"}

        };
        private static readonly List<List<ArrMapNames>> BookLeveLocations = new List<List<ArrMapNames>>
        {
            new List<ArrMapNames>{ArrMapNames.NorthernThanalan,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.MorDhona},
            new List<ArrMapNames>{ArrMapNames.NorthernThanalan,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.MorDhona},
            new List<ArrMapNames>{ArrMapNames.NorthernThanalan,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.MorDhona},
            new List<ArrMapNames>{ArrMapNames.NorthernThanalan,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.MorDhona},
            new List<ArrMapNames>{ArrMapNames.NorthernThanalan,ArrMapNames.MorDhona,ArrMapNames.CoerthasCentralHighlands},
            new List<ArrMapNames>{ArrMapNames.CoerthasCentralHighlands,ArrMapNames.NorthernThanalan,ArrMapNames.MorDhona},
            new List<ArrMapNames>{ArrMapNames.NorthernThanalan,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.MorDhona},
            new List<ArrMapNames>{ArrMapNames.NorthernThanalan,ArrMapNames.CoerthasCentralHighlands,ArrMapNames.MorDhona},
            new List<ArrMapNames>{ArrMapNames.NorthernThanalan,ArrMapNames.MorDhona,ArrMapNames.CoerthasCentralHighlands}

        };
        private static readonly List<List<PointF>> BookLevePoints = new List<List<PointF>>
        {
            new List<PointF>{new PointF(22F,29F),new PointF(11.9F,16.8F),new PointF(30F,12F)},
            new List<PointF>{new PointF(22F,29F),new PointF(11F,16F),new PointF(30F,12F)},
            new List<PointF>{new PointF(22F,29F),new PointF(11F,16F),new PointF(30F,12F)},
            new List<PointF>{new PointF(22F,29F),new PointF(12F,16F),new PointF(30F,12F)},
            new List<PointF>{new PointF(22F,29F),new PointF(30F,12F),new PointF(11F,16F)},
            new List<PointF>{new PointF(12F,16F),new PointF(22F,29F),new PointF(30F,12F)},
            new List<PointF>{new PointF(22F,29F),new PointF(11F,16F),new PointF(29F,12F)},
            new List<PointF>{new PointF(22F,29F),new PointF(11F,16F),new PointF(29F,12F)},
            new List<PointF>{new PointF(22F,29F),new PointF(29F,12F),new PointF(11F,16F)}
        };

        
        #endregion

    }
    
    public enum ArrMapNames
    {
        [Display(Name = "NA")]
        NA,
        [Display(Name = "Middle La Noscea")]
        MiddleLaNoscea,
        [Display(Name= "Lower La Noscea")]
        LowerLaNoscea,
        [Display(Name= "Eastern La Noscea")]
        EasternLaNoscea,
        [Display(Name= "Western La Noscea")]
        WesternLaNoscea,
        [Display(Name= "Upper La Noscea")]
        UpperLaNoscea,
        [Display(Name= "Outer La Noscea")]
        OuterLaNoscea,
        [Display(Name= "Central Shroud")]
        CentralShroud,
        [Display(Name= "East Shroud")]
        EastShroud,
        [Display(Name= "South Shroud")]
        SouthShroud,
        [Display(Name= "North Shroud")]
        NorthShroud,
        [Display(Name= "Western Thanalan")]
        WesternThanalan,
        [Display(Name= "Central Thanalan")]
        CentralThanalan,
        [Display(Name= "Eastern Thanalan")]
        EasternThanalan,
        [Display(Name= "Southern Thanalan")]
        SouthernThanalan,
        [Display(Name= "Northern Thanalan")]
        NorthernThanalan,
        [Display(Name= "Mor Dhona")]
        MorDhona,
        [Display(Name= "Coerthas Central Highlands")]
        CoerthasCentralHighlands
    }
    public enum AnimusBookNames
    {
        [Display(Name ="N/A")]
        NA,
        [Display(Name ="Book of Skyfire I")]
        SkyFire1Book,
        [Display(Name ="Book of Skyfire II")]
        SkyFire2Book,
        [Display(Name ="Book of Netherfire I")]
        NetherFire1Book,
        [Display(Name ="Book of Skyfall I")]
        SkyFall1Book,
        [Display(Name ="Book of Skyfall II")]
        SkyFall2Book,
        [Display(Name ="Book of Netherfall I")]
        NetherFall1Book,
        [Display(Name ="Book of Skywind I")]
        SkyWind1Book,
        [Display(Name ="Book of Skywind II")]
        SkyWind2Book,
        [Display(Name ="Book of Skyearth I")]
        SkyEarth1Book
    }
}
