namespace CreatePicture.Creators
{
    internal class RandPicture : PictureCreator
    {
        public override int B(int x, int y) => rand(C);

        public override int G(int x, int y) => rand(C);

        public override int R(int x, int y) => rand(C);
    }
}
