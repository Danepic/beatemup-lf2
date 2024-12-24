using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public class CharacterSelectionService
    {
        public List<Booster> FindBoosters()
        {
            //cacheado
            return new List<Booster>
            {
                new("3f0a412f-d06b-45de-b4cd-d1234567890a", "Hero Come Back", 18, "UI/Boosters/1-hero-come-back", DateTime.Now, DateTime.Now, 1),
                new("4a7b123f-a69e-4a3f-bbcd-e89012345678", "Heroes from Another Time", 9, "UI/Boosters/2-heroes-from-another-time", DateTime.Now, DateTime.Now, 2)
            };
        }

        public List<Character> FindCharacters()
        {
            //cacheado
            return new List<Character>
            {
                new ("081e0659-4c10-41d9-98d4-43270909c14b", "Naruto Uzumaki", "NS", "Chars/naruto/ns-naruto-base", "3f0a412f-d06b-45de-b4cd-d1234567890a", 1),
                new ("d395f862-3453-4d0a-bcb3-388591b82b1e", "Sakura Haruno", "NS", "Chars/sakura/ns-sakura-base", "3f0a412f-d06b-45de-b4cd-d1234567890a", 2),
                new ("e12f65a3-bd3f-4c7c-a7a9-1f6f64f89bc3", "Kakashi Hatake", "NS", "Chars/kakashi/ns-kakashi-base/kakashi", "3f0a412f-d06b-45de-b4cd-d1234567890a", 3),
                new ("41bc9d1f-4571-468b-998c-57c8e781e749", "Shikamaru Nara", "NS", "Chars/shikamaru/ns-shikamaru-base/shikamaru", "3f0a412f-d06b-45de-b4cd-d1234567890a", 4),
                new ("0eac457d-b251-4d13-9e3d-7669b0f9b003", "Gaara", "NS", "Chars/gaara/ns-gaara-base/gaara", "3f0a412f-d06b-45de-b4cd-d1234567890a", 5),
                new ("c0b16a04-5b42-4ea3-a6d8-d3b6824c3aa3", "Kankuro", "NS", "Chars/kankuro/ns-kankuro-base/kankuro", "3f0a412f-d06b-45de-b4cd-d1234567890a", 6),
                new ("fae12078-7c5b-4d07-a053-9ab4d9f4d5fa", "Temari", "NS", "Chars/temari/ns-temari-base/temari", "3f0a412f-d06b-45de-b4cd-d1234567890a", 7),
                new ("2cde0f6c-16f4-4ec6-8f74-769b1d0ad4b5", "Chiyo", "NS", "Chars/chiyo/ns-chiyo-base/chiyo", "3f0a412f-d06b-45de-b4cd-d1234567890a", 8),
                new ("86f73960-0b94-45a1-8e0f-d6ae2b34bfbf", "Might Guy", "NS", "Chars/guy/ns-guy-base/guy", "3f0a412f-d06b-45de-b4cd-d1234567890a", 9),
                new ("5a013f9a-514d-4a83-8a47-1b60f05d39e3", "Rock Lee", "NS", "Chars/lee/ns-lee-base/lee", "3f0a412f-d06b-45de-b4cd-d1234567890a", 10),
                new ("4f305b7e-7f3f-4a48-a951-9f65e3d1a9d7", "Tenten", "NS", "Chars/tenten/ns-tenten-base/tenten", "3f0a412f-d06b-45de-b4cd-d1234567890a", 11),
                new ("1e3c8756-b2b7-4b12-bf5e-4d5d78b98e41", "Neji Hyuga", "NS", "Chars/neji/ns-neji-base/neji", "3f0a412f-d06b-45de-b4cd-d1234567890a", 12),
                new ("987a2f14-566b-4afc-89c9-81e3c4a5e2de", "Itachi Uchiha", "NS", "Chars/itachi/ns-itachi-base/itachi", "3f0a412f-d06b-45de-b4cd-d1234567890a", 13),
                new ("f139e271-7581-4a1c-8d91-d423689fb3ea", "Kisame Hoshigaki", "NS", "Chars/kisame/ns-kisame-base/kisame", "3f0a412f-d06b-45de-b4cd-d1234567890a", 14),
                new ("723fa817-c7ea-44f4-8f2c-2f2a0f2dcefa", "Deidara", "NS", "Chars/deidara/ns-deidara-base/deidara", "3f0a412f-d06b-45de-b4cd-d1234567890a", 15),
                new ("92b61b60-e507-4d12-a60c-e24b2c54df1a", "Sasori", "NS", "Chars/sasori/ns-sasori-base/sasori", "3f0a412f-d06b-45de-b4cd-d1234567890a", 16),
                new ("7ed5e3e9-859b-43b4-b412-e2d42c45a71d", "Sasori Puppet", "NS", "Chars/sasori_puppet/ns-sasori-puppet-base/sasori_puppet", "3f0a412f-d06b-45de-b4cd-d1234567890a", 17),
                new ("3cb95dfd-f2b5-4f62-889b-b8f21f4cfcfe", "Hiruko", "NS", "Chars/hiruko/ns-hiruko-base/hiruko", "3f0a412f-d06b-45de-b4cd-d1234567890a", 18),

                new ("c12a45b7-f31b-4f2a-b40f-87d4a5c45678", "Naruto Uzumaki", "B", "Chars/naruto/timeskip-naruto", "4a7b123f-a69e-4a3f-bbcd-e89012345678", 1),
                new ("d21b43f9-86a1-4d3c-9b4d-56e7a4c56789", "Sasuke Uchiha", "B", "Chars/sasuke/timeskip-sasuke", "4a7b123f-a69e-4a3f-bbcd-e89012345678", 2),
                new ("e34f21c9-96a2-4b5f-9e7d-68a2c4b78910", "Sakura Haruno", "B", "Chars/sakura/timeskip-sakura", "4a7b123f-a69e-4a3f-bbcd-e89012345678", 3),
                new ("a45b23d9-89a3-4d7c-8f7d-12e3a4d89011", "Kakashi Hatake", "B", "Chars/kakashi/timeskip-kakashi", "4a7b123f-a69e-4a3f-bbcd-e89012345678", 4),
                new ("f12a45e7-56a4-4b5e-8c7e-89d2e4c90112", "Boruto Uzumaki", "B", "Chars/boruto/base-boruto", "4a7b123f-a69e-4a3f-bbcd-e89012345678", 5),
                new ("e34c21b8-78a1-4f5c-9d2a-45d7e4c12345", "Naruto Uzumaki", "N", "Chars/naruto/kid-naruto", "4a7b123f-a69e-4a3f-bbcd-e89012345678", 6),
                new ("f23a12c7-67b4-4f8e-8d1f-23d7e5c23456", "Sasuke Uchiha", "N", "Chars/sasuke/kid-sasuke", "4a7b123f-a69e-4a3f-bbcd-e89012345678", 7),
                new ("e12c34b8-45a1-4d5e-9f3a-56a7e4c34567", "Naruto Uzumaki", "NS", "Chars/naruto/training-naruto", "4a7b123f-a69e-4a3f-bbcd-e89012345678", 8),
                new ("d23a12c9-78b1-4f7c-9d3a-12e5a4c45678", "Jiraiya", "N", "Chars/jiraiya/base-jiraiya", "4a7b123f-a69e-4a3f-bbcd-e89012345678", 9),
            };
        }

        public List<Character> FindUserCharacters()
        {
            //cacheado
            return new List<Character>{
                new ("081e0659-4c10-41d9-98d4-43270909c14b", "Naruto Uzumaki", "NS", "Chars/naruto/ns-naruto-base/naruto_mugshot", "3f0a412f-d06b-45de-b4cd-d1234567890a", 1),
                new ("d395f862-3453-4d0a-bcb3-388591b82b1e", "Sakura Haruno", "NS", "Chars/sakura/ns-sakura-base", "3f0a412f-d06b-45de-b4cd-d1234567890a", 2),
            };
        }

        public void FindMugshotsByBooster()
        {
            throw new NotImplementedException();
        }

        public List<Stage> FindUserStages()
        {
            // Cacheado
            return new List<Stage>
            {
                new Stage(
                    "123e4567-e89b-12d3-a456-426614174000",
                    "Rocks - Day",
                    "Small",
                    "Backgrounds/rocks-day",
                    "3f0a412f-d06b-45de-b4cd-d1234567890a",
                    1
                )
            };
        }
    }
}