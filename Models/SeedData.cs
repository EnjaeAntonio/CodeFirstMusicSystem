using CodeFirstMusicSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstMusicSystem.Models
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new MusicSystemContext(serviceProvider.GetRequiredService<DbContextOptions<MusicSystemContext>>());
            context.Database.EnsureCreated();

            context.Database.Migrate();

            Artist artistOne = new Artist("NBA Youngboy");
            Artist artistTwo = new Artist("Drake");
            Artist artistThree = new Artist("SZA");

            if (!context.Artist.Any())
            {
                context.Artist.Add(artistOne);  
                context.Artist.Add(artistTwo);
                context.Artist.Add(artistThree);
                await context.SaveChangesAsync();
            }


            if(!context.Artist.Any())
            {
                int test = artistOne.Id;
                int testTwo = artistTwo.Id;
                int testThree = artistThree.Id;
                await context.SaveChangesAsync();

            }

            Album albumOne = new Album("Top", new DateTime(2020, 9, 11));
            Album albumTwo = new Album("Realer 2", new DateTime(2022, 9, 7));
            Album albumThree = new Album("Her Loss", new DateTime(2022, 11, 4));
            Album albumFour = new Album("Scorpion", new DateTime(2018, 6, 29));
            Album albumFive = new Album("SOS", new DateTime(2022, 12, 9));
            Album albumSix = new Album("CTRL", new DateTime(2017, 6, 9));

            if (!context.Album.Any())
            {
                context.Album.Add(albumOne);
                context.Album.Add(albumTwo);
                context.Album.Add(albumThree);
                context.Album.Add(albumFour);
                context.Album.Add(albumFive);
                context.Album.Add(albumSix);
                await context.SaveChangesAsync();
            }

            // NBA Youngboy songs
            Song songOne = new Song("White Teeth", 165, albumOne.Id);
            Song songTwo = new Song("Toxic Punk", 182, albumOne.Id);
            Song songThree = new Song("Drug Addiction", 215, albumOne.Id);
            Song songFour = new Song("I'm The One", 159, albumTwo.Id);
            Song songFive = new Song("2 Seater", 175, albumTwo.Id);
            Song songSix = new Song("Diamond Teeth Samurai", 187, albumTwo.Id);
            Song songSeven = new Song("Genie", 177, albumTwo.Id);
            // Drake songs


            Song songEight = new Song("Good Days", 260, albumThree.Id);
            Song songNine = new Song("The Anonymous Ones", 231, albumThree.Id);
            Song songTen = new Song("I Hate You", 211, albumThree.Id);
            Song songEleven = new Song("God's Plan", 200, albumFour.Id);
            Song songTwelve = new Song("Nonstop", 308, albumFour.Id);
            Song songThirteen = new Song("In My Feelings", 217, albumFour.Id);
            Song songFourteen = new Song("Nice For What", 210, albumFour.Id);

            // SZA Songs

            Song songFifteen = new Song("Gone", 184, albumFive.Id);
            Song songSixteen = new Song("I Hate You", 202, albumFive.Id);
            Song songSeventeen = new Song("The Anonymous Ones", 207, albumFive.Id);
            Song songEighteen = new Song("Supermodel", 219, albumSix.Id);
            Song songNineteen = new Song("Drew Barrymore", 242, albumSix.Id);
            Song songTwenty = new Song("The Weekend", 268, albumSix.Id);



            if (!context.Song.Any())
            {
                context.Song.Add(songOne);
                context.Song.Add(songTwo);
                context.Song.Add(songThree);
                context.Song.Add(songFour);
                context.Song.Add(songFive);
                context.Song.Add(songSix);
                context.Song.Add(songSeven);
                context.Song.Add(songEight);
                context.Song.Add(songNine);
                context.Song.Add(songTen);
                context.Song.Add(songEleven);
                context.Song.Add(songTwelve);
                context.Song.Add(songThirteen);
                context.Song.Add(songFourteen);
                context.Song.Add(songFifteen);
                context.Song.Add(songSixteen);
                context.Song.Add(songSeventeen);
                context.Song.Add(songEighteen);
                context.Song.Add(songNineteen);
                context.Song.Add(songTwenty);

                await context.SaveChangesAsync();
            }
            SongContributor artistSongOne = new SongContributor(artistOne.Id, songOne.Id);
            SongContributor artistSongTwo = new SongContributor(artistOne.Id, songTwo.Id);
            SongContributor artistSongThree = new SongContributor(artistOne.Id, songThree.Id);
            SongContributor artistSongFour = new SongContributor(artistOne.Id, songFour.Id);
            SongContributor artistSongFive = new SongContributor(artistOne.Id, songFive.Id);
            SongContributor artistSongSix = new SongContributor(artistOne.Id, songSix.Id);
            SongContributor artistSongSeven = new SongContributor(artistOne.Id, songSeven.Id);
            SongContributor artistSongEight = new SongContributor(artistTwo.Id, songEight.Id);
            SongContributor artistSongNine = new SongContributor(artistTwo.Id, songNine.Id);
            SongContributor artistSongTen = new SongContributor(artistTwo.Id, songTen.Id);
            SongContributor artistSongEleven = new SongContributor(artistTwo.Id, songEleven.Id);
            SongContributor artistSongTwelve = new SongContributor(artistTwo.Id, songTwelve.Id);
            SongContributor artistSongThirteen = new SongContributor(artistTwo.Id, songThirteen.Id);
            SongContributor artistSongFourteen = new SongContributor(artistTwo.Id, songFourteen.Id);
            SongContributor artistSongFifteen = new SongContributor(artistThree.Id, songFifteen.Id);
            SongContributor artistSongSixteen = new SongContributor(artistThree.Id, songSixteen.Id);
            SongContributor artistSongSeventeen = new SongContributor(artistThree.Id, songSeventeen.Id);
            SongContributor artistSongEighteen = new SongContributor(artistThree.Id, songEighteen.Id);
            SongContributor artistSongNineteen = new SongContributor(artistThree.Id, songNineteen.Id);
            SongContributor artistSongTwenty = new SongContributor(artistThree.Id, songTwenty.Id);

            if (!context.SongContributor.Any())
            {
                context.SongContributor.Add(artistSongOne);
                context.SongContributor.Add(artistSongTwo);
                context.SongContributor.Add(artistSongThree);
                context.SongContributor.Add(artistSongFour);
                context.SongContributor.Add(artistSongFive);
                context.SongContributor.Add(artistSongSix);
                context.SongContributor.Add(artistSongSeven);
                context.SongContributor.Add(artistSongEight);
                context.SongContributor.Add(artistSongNine);
                context.SongContributor.Add(artistSongTen);
                context.SongContributor.Add(artistSongEleven);
                context.SongContributor.Add(artistSongTwelve);
                context.SongContributor.Add(artistSongThirteen);
                context.SongContributor.Add(artistSongFourteen);
                context.SongContributor.Add(artistSongFifteen);
                context.SongContributor.Add(artistSongSixteen);
                context.SongContributor.Add(artistSongSeventeen);
                context.SongContributor.Add(artistSongEighteen);
                context.SongContributor.Add(artistSongNineteen);
                context.SongContributor.Add(artistSongTwenty);
            }
            await context.SaveChangesAsync();
        }
    }
}
