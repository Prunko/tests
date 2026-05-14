using System;
using System.Collections.Generic;
using System.Text;

namespace ht15
{
    internal class Playlist
    {
        public Dictionary<int, string> _songList = new Dictionary<int, string>()
        {
            { 1, "Song 1" },
            { 2, "Song 2" },
            { 3, "Song 3" },
            { 4, "Song 4" },
            { 5, "Song 5" },
            { 6, "Song 6" },
            { 7, "Song 7" },
            { 8, "Song 8" },
            { 9, "Song 9" },
            { 10, "Song 10" },
            { 11, "Song 11" },
            { 12, "Song 12" },
            { 13, "Song 13" },
        };
        public Queue<string> SongQueue = new Queue<string>();

        public void Play()
        {
            foreach (var song in _songList)
            {
                SongQueue.Enqueue(song.Value);
            }

            while (SongQueue.Count > 0)
            {
                string song = SongQueue.Dequeue();
                Console.WriteLine($"Now playing: {song}");
            }
        }

        public void PlayShuffle()
        {
            while(SongQueue.Count < 5)
            {
                int randomId = Random.Shared.Next(1, _songList.Count);
                if (SongQueue.Contains(_songList[randomId]))
                {
                    continue;
                } else
                {
                    SongQueue.Enqueue(_songList[randomId]);
                }
            }

            while (SongQueue.Count > 0)
            {
                string song = SongQueue.Dequeue();
                Console.WriteLine($"Now playing: {song}");
            }
        }
    }
}
