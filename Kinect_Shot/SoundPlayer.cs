using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.ColorBasics
{
    class SoundPlayer
    {
        // 音声ファイルのファイル名を格納する配列
        System.IO.UnmanagedMemoryStream[] AudioFile = new System.IO.UnmanagedMemoryStream[3];

        // 音声を再生するためのクラス
        private System.Media.SoundPlayer Player = null;

        // ファイルを読み込み初期化する
        private void Initialize()
        {
            AudioFile[0] = Properties.Resources.Sound1;
            AudioFile[1] = Properties.Resources.Sound2;
            AudioFile[2] = Properties.Resources.Sound3;
        }

        // サウンドを再生する
        public void SoundPlay(int time)
        {
            Initialize();

            // すでに再生されている場合は停止する
            if (Player != null)
            {
                StopSound();
            }

            // 音声を読み込む
            Player = new System.Media.SoundPlayer(AudioFile[time - 1]);

            // 再生し、再生し終わるまで待機
            Player.PlaySync();
        }


        // 再生を止める
        public void StopSound()
        {
            if (Player != null)
            {
                Player.Stop();
                Player.Dispose();
                Player = null;
            }
        }
    }
}
