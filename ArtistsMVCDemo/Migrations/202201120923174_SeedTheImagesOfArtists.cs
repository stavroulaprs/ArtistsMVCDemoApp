namespace ArtistsMVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTheImagesOfArtists : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Artists SET Thumbnail = 'na_image.jpg'");
        }
        
        public override void Down()
        {
            Sql("UPDATE Artists SET Thumbnail = ''");
        }
    }
}
