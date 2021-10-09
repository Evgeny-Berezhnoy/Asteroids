namespace Interpreters
{

    public static class GamePoints
    {

        #region Methods

        public static string GetRepresentation(int points)
        {

            if (points < 1000)
            {

                return points.ToString();

            }
            else if (points < 1000000)
            {

                return $"{points / 1000}K";

            }
            else
            {

                return $"{points / 1000000}M";

            };

        }

        #endregion

    }

}