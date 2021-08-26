namespace SongsinkModel
{
    public class LeaderBoard 
    {
        public LeaderBoard()
        { }

        public int Id { get; set; }
        public string nickName { get; set; }
        public int currentScore { get; set; }
        public int overallScore { get; set; }
    }
}