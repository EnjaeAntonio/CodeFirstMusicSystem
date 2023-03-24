using CodeFirstMusicSystem.Data;
using CodeFirstMusicSystem.Migrations;
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


            if (!context.Artist.Any())
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
            Song songOne = new Song(1, "White Teeth", 165, albumOne.Id);
            Song songTwo = new Song(2, "Toxic Punk", 182, albumOne.Id);
            Song songThree = new Song(3, "Drug Addiction", 215, albumOne.Id);
            Song songFour = new Song(1,"I'm The One", 159, albumTwo.Id);
            Song songFive = new Song(2,"2 Seater", 175, albumTwo.Id);
            Song songSix = new Song(3,"Diamond Teeth Samurai", 187, albumTwo.Id);
            Song songSeven = new Song(4,"Genie", 177, albumTwo.Id);
            // Drake songs


            Song songEight = new Song(1,"Good Days", 260, albumThree.Id);
            Song songNine = new Song(2,"The Anonymous Ones", 231, albumThree.Id);
            Song songTen = new Song(3,"I Hate You", 211, albumThree.Id);
            Song songEleven = new Song(1,"God's Plan", 200, albumFour.Id);
            Song songTwelve = new Song(2,"Nonstop", 308, albumFour.Id);
            Song songThirteen = new Song(3,"In My Feelings", 217, albumFour.Id);
            Song songFourteen = new Song(4,"Nice For What", 210, albumFour.Id);

            // SZA Songs

            Song songFifteen = new Song(1,"Gone", 184, albumFive.Id);
            Song songSixteen = new Song(2,"I Hate You", 202, albumFive.Id);
            Song songSeventeen = new Song(3,"The Anonymous Ones", 207, albumFive.Id);
            Song songEighteen = new Song(1,"Supermodel", 219, albumSix.Id);
            Song songNineteen = new Song(2,"Drew Barrymore", 242, albumSix.Id);
            Song songTwenty = new Song(3,"The Weekend", 268, albumSix.Id);

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
                await context.SaveChangesAsync();
            }

            Playlist playlistOne = new Playlist("Enjae's Playlist");
            Playlist playlistTwo = new Playlist("Gym Playlist");
            Playlist playlistThree = new Playlist("Cruising Playlist");

            if (!context.Playlist.Any())
            {
                context.Playlist.Add(playlistOne);
                context.Playlist.Add(playlistTwo);
                context.Playlist.Add(playlistThree);
                await context.SaveChangesAsync();
            }

            PlaylistSong playlistSongOne = new PlaylistSong(playlistOne.Id, songOne.Id);    

            if(!context.PlaylistSong.Any())
            {
                context.PlaylistSong.Add(playlistSongOne);
                await context.SaveChangesAsync();

            }

            Podcast podcastOne = new Podcast("The Rogan Experience", new DateTime(2009, 12, 24));
            Podcast podcastTwo = new Podcast("StartUp Podcast", new DateTime(2014, 10, 16));
            Podcast podcastThree = new Podcast("The Health Code", new DateTime(2018, 4, 2));
            Podcast podcastFour = new Podcast("Impaulsive", new DateTime(2018, 11, 19));
            if (!context.Podcast.Any())
            {

                context.Podcast.Add(podcastOne);
                context.Podcast.Add(podcastTwo);
                context.Podcast.Add(podcastThree);
                context.Podcast.Add(podcastFour);

                await context.SaveChangesAsync();
            }

            PodcastArtist podcastArtistJoeRogan = new PodcastArtist("Joe Rogan");

            PodcastArtist podcastArtistAlexBlumberg = new PodcastArtist("Alex Blumberg");

            PodcastArtist podcastArtistSarahDay = new PodcastArtist("Sarah Day");

            PodcastArtist podcastArtistLoganPaul = new PodcastArtist("Logan Paul");

            if (!context.PodcastArtists.Any())
            {
                context.PodcastArtists.Add(podcastArtistJoeRogan);
                context.PodcastArtists.Add(podcastArtistAlexBlumberg);
                context.PodcastArtists.Add(podcastArtistSarahDay);
                context.PodcastArtists.Add(podcastArtistLoganPaul);

                await context.SaveChangesAsync();
            }

            // PodcastCastArtist 1
            PodcastCastArtist podcastCastArtistOne = new PodcastCastArtist(podcastOne.Id, podcastArtistJoeRogan.Id);

            // PodcastCastArtist 2
            PodcastCastArtist podcastCastArtistTwo = new PodcastCastArtist(podcastTwo.Id, podcastArtistAlexBlumberg.Id);

            // PodcastCastArtist 3
            PodcastCastArtist podcastCastArtistThree = new PodcastCastArtist(podcastThree.Id, podcastArtistSarahDay.Id);

            // PodcastCastArtist 4
            PodcastCastArtist podcastCastArtistFour = new PodcastCastArtist(podcastFour.Id, podcastArtistLoganPaul.Id);

            if (!context.PodcastCastArtists.Any())
            {
                context.PodcastCastArtists.Add(podcastCastArtistOne);
                context.PodcastCastArtists.Add(podcastCastArtistTwo);
                context.PodcastCastArtists.Add(podcastCastArtistThree);
                context.PodcastCastArtists.Add(podcastCastArtistFour);

                await context.SaveChangesAsync();
            }

            // Episodes for Podcast 1
            Episode episodeOneA = new Episode("#1609 - Elon Musk", new DateTime(2021, 02, 21)) { PodcastId = podcastOne.Id };
            Episode episodeOneB = new Episode("#1610 - Snowpocalypse with Tim Dillon", new DateTime(2021, 02, 26)) { PodcastId = podcastOne.Id };
            Episode episodeOneC = new Episode("#1611 - Freddie Gibbs & Brian Moses", new DateTime(2021, 02, 28)) { PodcastId = podcastOne.Id };

            // Episodes for Podcast 2
            Episode episodeTwoA = new Episode("How Not to Pitch a Billionaire", new DateTime(2014, 10, 16)) { PodcastId = podcastTwo.Id };
            Episode episodeTwoB = new Episode("Is Podcasting the Future of Media?", new DateTime(2014, 10, 23)) { PodcastId = podcastTwo.Id };
            Episode episodeTwoC = new Episode("How to Divide an Imaginary Pie", new DateTime(2014, 10, 30)) { PodcastId = podcastTwo.Id };

            // Episodes for Podcast 3
            Episode episodeThreeA = new Episode("Our Fitness Journey & Tips", new DateTime(2018, 04, 02)) { PodcastId = podcastThree.Id };
            Episode episodeThreeB = new Episode("Balancing Health & Social Life", new DateTime(2018, 04, 09)) { PodcastId = podcastThree.Id };
            Episode episodeThreeC = new Episode("Conquering Self-Doubt", new DateTime(2018, 04, 16)) { PodcastId = podcastThree.Id };

            // Episodes for Podcast 4
            Episode episodeFourA = new Episode("The Truth About Logan Paul", new DateTime(2018, 11, 19)) { PodcastId = podcastFour.Id };
            Episode episodeFourB = new Episode("The Most Influential Woman on Earth", new DateTime(2018, 11, 26)) { PodcastId = podcastFour.Id };
            Episode episodeFourC = new Episode("The Real Reason I Left Vine", new DateTime(2018, 12, 03)) { PodcastId = podcastFour.Id };

            if (!context.Episode.Any())
            {
                context.Episode.AddRange(new List<Episode>
            {
                episodeOneA, episodeOneB, episodeOneC,
                episodeTwoA, episodeTwoB, episodeTwoC,
                episodeThreeA, episodeThreeB, episodeThreeC,
                episodeFourA, episodeFourB, episodeFourC
            });

                await context.SaveChangesAsync();
            }

            GuestArtist guestElonMusk = new GuestArtist("Elon Musk");
            GuestArtist guestTimDillon = new GuestArtist("Tim Dillon");
            GuestArtist guestFreddieGibbs = new GuestArtist("Freddie Gibbs & Brian Moses");

            GuestArtist guestChrisSacca = new GuestArtist("Chris Sacca");
            GuestArtist guestAndrewMason = new GuestArtist("Andrew Mason");
            GuestArtist guestMattLieber = new GuestArtist("Matt Lieber");

            GuestArtist guestKaylaItsines = new GuestArtist("Kayla Itsines");
            GuestArtist guestStephanieButtermore = new GuestArtist("Stephanie Buttermore");
            GuestArtist guestAmandaBucci = new GuestArtist("Amanda Bucci");

            GuestArtist guestMikeMajlak = new GuestArtist("Mike Majlak");
            GuestArtist guestCandaceOwens = new GuestArtist("Candace Owens");
            GuestArtist guestBrittanyFurlan = new GuestArtist("Brittany Furlan");


            if (!context.GuestArtists.Any())
            {
                context.GuestArtists.AddRange(new List<GuestArtist>
            {
                guestElonMusk, guestTimDillon, guestFreddieGibbs,
                guestChrisSacca, guestAndrewMason, guestMattLieber,
                guestKaylaItsines, guestStephanieButtermore, guestAmandaBucci,
                guestMikeMajlak, guestCandaceOwens, guestBrittanyFurlan
            });

                await context.SaveChangesAsync();
            }
            // GuestArtistEpisode relationships for Podcast 1
            GuestArtistEpisode guestArtistEpisodeOneA = new GuestArtistEpisode(episodeOneA.Id, guestElonMusk.Id);
            GuestArtistEpisode guestArtistEpisodeOneB = new GuestArtistEpisode(episodeOneB.Id, guestTimDillon.Id);
            GuestArtistEpisode guestArtistEpisodeOneC1 = new GuestArtistEpisode(episodeOneC.Id, guestFreddieGibbs.Id);

            // GuestArtistEpisode relationships for Podcast 2
            GuestArtistEpisode guestArtistEpisodeTwoA = new GuestArtistEpisode(episodeTwoA.Id, guestChrisSacca.Id);
            GuestArtistEpisode guestArtistEpisodeTwoB = new GuestArtistEpisode(episodeTwoB.Id, guestAndrewMason.Id);
            GuestArtistEpisode guestArtistEpisodeTwoC = new GuestArtistEpisode(episodeTwoC.Id, guestMattLieber.Id);

            // GuestArtistEpisode relationships for Podcast 3
            GuestArtistEpisode guestArtistEpisodeThreeA = new GuestArtistEpisode(episodeThreeA.Id, guestKaylaItsines.Id);
            GuestArtistEpisode guestArtistEpisodeThreeB = new GuestArtistEpisode(episodeThreeB.Id, guestStephanieButtermore.Id);
            GuestArtistEpisode guestArtistEpisodeThreeC = new GuestArtistEpisode(episodeThreeC.Id, guestAmandaBucci.Id);

            // GuestArtistEpisode relationships for Podcast 4
            GuestArtistEpisode guestArtistEpisodeFourA = new GuestArtistEpisode(episodeFourA.Id, guestMikeMajlak.Id);
            GuestArtistEpisode guestArtistEpisodeFourB = new GuestArtistEpisode(episodeFourB.Id, guestCandaceOwens.Id);
            GuestArtistEpisode guestArtistEpisodeFourC = new GuestArtistEpisode(episodeFourC.Id, guestBrittanyFurlan.Id);

            if (!context.GuestArtistEpisodes.Any())
            {
                context.GuestArtistEpisodes.AddRange(new List<GuestArtistEpisode>
            {
                guestArtistEpisodeOneA, guestArtistEpisodeOneB, guestArtistEpisodeOneC1,
                guestArtistEpisodeTwoA, guestArtistEpisodeTwoB, guestArtistEpisodeTwoC,
                guestArtistEpisodeThreeA, guestArtistEpisodeThreeB, guestArtistEpisodeThreeC,
                guestArtistEpisodeFourA, guestArtistEpisodeFourB, guestArtistEpisodeFourC
            });

                await context.SaveChangesAsync();
            }


            ListenerList enjaeListener = new ListenerList("Enjae Antonio Listener List");
            ListenerList kinahListener = new ListenerList("Kinah Javier Listener List");

            if (!context.ListenerList.Any())
            {
                context.ListenerList.Add(enjaeListener);
                context.ListenerList.Add(kinahListener);
                await context.SaveChangesAsync();
            }

            PodcastListenerList podcastListenerListOne = new PodcastListenerList(podcastOne.Id, kinahListener.Id);
            PodcastListenerList podcastListenerListTwo = new PodcastListenerList(podcastTwo.Id, kinahListener.Id);
            PodcastListenerList podcastListenerListThree = new PodcastListenerList(podcastThree.Id, enjaeListener.Id);
            PodcastListenerList podcastListenerListFour = new PodcastListenerList(podcastFour.Id, enjaeListener.Id);
            if (!context.PodcastListenerLists.Any())
            {

                podcastOne.PodcastListenerLists.Add(podcastListenerListOne);
                podcastTwo.PodcastListenerLists.Add(podcastListenerListTwo);
                podcastThree.PodcastListenerLists.Add(podcastListenerListThree);
                podcastFour.PodcastListenerLists.Add(podcastListenerListFour);
                context.PodcastListenerLists.Add(podcastListenerListOne);
                context.PodcastListenerLists.Add(podcastListenerListTwo);
                context.PodcastListenerLists.Add(podcastListenerListThree);
                context.PodcastListenerLists.Add(podcastListenerListFour);


                await context.SaveChangesAsync();
            }

            await context.SaveChangesAsync();
        }
    }
}
