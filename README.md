# CustomAvatarsLeftHandPatch

[BeatSaberCustomAvatars](https://github.com/nicoco007/BeatSaberCustomAvatars)のVer5.2.11で修正された左手のZ回転反転を元に戻すパッチです。

公式のコントローラ設定でZ軸を回転させている場合に、アバターの左手がひっくり返ってしまうのを戻します。

主に、modelsaberで配布されているアバターを使って、ViveコンのBグリップでZ軸を-90度回転している人向けです。

自分でアバターモデルを作ってる人は、LeftHandTargetを修正した方が良いです。

[この](https://github.com/nicoco007/BeatSaberCustomAvatars/blob/main/Source/CustomAvatar/Utilities/BeatSaberUtilities.cs#L94-L97)部分の処理を無くしたものに差し替えます。

----

This is a patch to revert the Z-rotation inversion of the left hand that was fixed in version 5.2.11 of [BeatSaberCustomAvatars](https://github.com/nicoco007/BeatSaberCustomAvatars).

It reverts the avatar's left hand from being flipped over when the Z-axis is rotated in the official controller settings.

This is mainly for people who are using avatars distributed by modelsaber and rotating the Z-axis by -90 degrees with the B-grip on the Vive console.

If you are creating your own avatar model, this patch is unnecessary if you modify LeftHandTarget.

[this](https://github.com/nicoco007/BeatSaberCustomAvatars/blob/main/Source/CustomAvatar/Utilities/BeatSaberUtilities.cs#L94-L97) part. Replace it with one that eliminates the processing.
