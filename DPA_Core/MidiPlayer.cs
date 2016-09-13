using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Core
{
    public class MidiPlayer : IDisposable
    {
        private OutputDevice _outDevice;

        // De inhoud voor de midi file ==> alle tracks + metaData
        private Sequence _sequence;

        // De midi speler
        // Deze maakt het mogelijk om een seuqence af te spelen
        // Heeft een timer en geeft event op de juiste momenten
        private Sequencer _sequencer;

        public MidiPlayer(OutputDevice outputDevice)
        {
            _outDevice = outputDevice;
            _sequencer = new Sequencer();

            // Wanneer een channelMessage langskomt wordt deze meteen doorgestuurd naar de audio
            _sequencer.ChannelMessagePlayed += ChannelMessagePlayed;

            // Wanneer de sequence klaar is ==> EndOfTrack event, moet alles geclosed worden
            _sequencer.PlayingCompleted += (playingSender, playingEvent) =>
            {
                _sequencer.Stop();
            };
        }

        public void Play(string midiFileLocation)
        {
            this._sequence = new Sequence();
            this._sequence.LoadCompleted += OnSequenceLoadCompleted;
            this._sequence.LoadAsync(midiFileLocation);
        }

        public void Play(Sequence sequence)
        {
            this._sequence = sequence;
            this._sequencer.Sequence = this._sequence;
            StartPlaying();
        }

        private void OnSequenceLoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _sequencer.Sequence = _sequence;
            StartPlaying();
        }

        private void StartPlaying()
        {
            _sequencer.Start();
        }

        private void ChannelMessagePlayed(object sender, ChannelMessageEventArgs e)
        {
            _outDevice.Send(e.Message);
        }

        public void Dispose()
        {
            _sequencer.Stop();
        }
    }
}
