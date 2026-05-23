# シェーダリファレンス

パッケージには 2 種類のシェーダが含まれています。プレハブの mirror マテリアルで切り替えてください:

## シェーダの種類

  - **PlayersOnlyMirror** - 透明度と距離フェード付きの通常バージョン
  - **PlayersOnlyMirrorCutout** - カットアウトのみのバリエーションで、透明度や距離フェードはありません。

## シェーダー設定

  - **Base (RBG)** - デフォルトのミラーシェーダーと同じ動作で、テクスチャを反射にオーバーレイします
  - **Hide Background** - 背景を非表示にします。これを機能させるには、ミラーの偽の背景として機能するTransparentBackgroundシェーダーが必要です。
  - **Ignore Effects** - パーティクルやレンズフレアなどの効果を無視しようとします。ただし、キャラクターの前にいる場合は表示されます。
  - **Transparency** - ミラーの透明度を調整します
  - **Transparency Mask** - ミラーの透明度を調整するテクスチャマスクは、完全に不透明な白から、黒で完全に透明になります。
  - **Distance Fade** - ミラーがゼロアルファにフェードし始めるまでの距離。 0で無効になります。
  - **Distance Fade Length** - 距離フェード長-ゼロアルファにフェードするために必要な移動距離の長さ。
  - **Smooth Edge** - エッジをよりスムーズにし、半透明オブジェクトが不透明になる現象を軽減します。
  - **Alpha Tweak Level** - Smooth Edgeの影響度を調整します

## 欠点

  - Smooth Edgeをオンにした場合。
    - 使用するシェーダによっては、アバターの透明マテリアルの一部が正しく透明化されない場合があります。(UTSではこの問題があります)
  - Smooth Edgeを利用しない場合、
    - ほとんどの透明な素材は鏡の中では不透明に見えます
    - 粒子、添加剤などは黒い輪郭になります
  - ミラーの後ろまたは前にある透明なマテリアルは、ミラーによって上書きまたは上書きされる可能性があります。レンダリングキューを調整すると、ステンシルを使用した最後の手段として役立ちます。

## トグル / スライダー UI の色を変更する

UI 用の 4 つのスプライト (`Textures/Slider.png`, `SliderFill.png`, `ToggleBox.png`, `ToggleCheckbox.png`) は **白い形状＋透明背景** で配布されており、プレハブ上の各 `Image` コンポーネントの `Color` フィールドで色付けされています (デフォルトは水色 `r: 0.392, g: 0.498, b: 0.678` ／ スライダーの埋まり部分のみ濃いめの `0.225, 0.286, 0.388`)。

色を変えるには、プレハブ配下の該当 `Image` GameObject を選び、`Color` フィールドで任意の色を選ぶだけです (テクスチャ編集不要):

  - **トグルの外枠** — `MirrorToggle/Background` の Image
  - **トグルのチェックマーク** — `MirrorToggle/Background/Checkmark` の Image
  - **スライダーのトラック / ハンドル** — `TransparencySlider/Background`, `TransparencySlider/Handle Slide Area/Handle` の Image
  - **スライダーの埋まり部分** — `TransparencySlider/Fill Area/Fill` の Image

## 「VRC Mirror Reflection」コンポーネントの設定

ミラーに背景が残っている場合は、`Mirror` GameObject の `VRC_MirrorReflection` コンポーネントがプレハブの初期構成のままになっているか確認してください:

![vrcmirrorreflection](https://cdn.nyanpa.su/i/PiMX2EB0.jpg)
