# CustomAvatarsLeftHandPatch

[BeatSaberCustomAvatars](https://github.com/nicoco007/BeatSaberCustomAvatars)のVer5.2.11で修正された左手のZ回転反転を元に戻すパッチです。

公式のコントローラ設定でZ軸を回転させている場合に、アバターの左手がひっくり返ってしまうのを戻します。

主に、modelsaberで配布されているアバターを使って、ViveコンのBグリップでZ軸を-90度回転している人向けです。

自分でアバターモデルを作ってる人は、LeftHandTargetを修正した方が良いです。

[この](https://github.com/nicoco007/BeatSaberCustomAvatars/blob/main/Source/CustomAvatar/Utilities/BeatSaberUtilities.cs#L94-L97)部分の処理を無くしたものに差し替えます。
