namespace MERSoundPlacer.API
{
    public class API
    {
        public void OnRoundStarted()
        {
            AudioApi AudioApi = new AudioApi();
            AudioApi.PlayAudio();
        }

    }
}
