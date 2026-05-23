# VRCPlayersOnlyMirror v0.2.0 (SDK3 / UdonSharp)

素敵な地図で景色を眺めるか、自分の反射を見つめるかを選択するのにうんざりしていませんか？ 今、あなたは両方を同時に行うことができます！
VRCPlayersOnlyMirrorは、背景のないプレーヤーのみを表示するシンプルなミラーprefabです。
これは切り抜かれた2Dカメラではなく、完全な3Dミラーです。

  - 背景のない鏡でのプレイヤーの反射
  - 調整可能なミラーの透明度
  - 単純な距離フェード
  - PCとQuestの両方の世界で動作します
  - LQミラーとほぼ同等の性能コスト

# 要件
  - Unity **2022.3.22f1** (VRChat 現行サポート版)
  - [Creator Companion](https://vcc.docs.vrchat.com/) から導入する VPM パッケージ:
    - `com.vrchat.worlds`
    - `com.vrchat.udonsharp`

Udon / UdonSharp の概要は [VRChat Udon ドキュメント](https://creators.vrchat.com/worlds/udon/) を参照してください。

# 方法

  - VCC で新規 **World** プロジェクトを作成し、`com.vrchat.udonsharp` パッケージを追加します。
  - この `VRCPlayersOnlyMirror` フォルダをプロジェクトの `Assets/` に配置するだけです。`.meta` ファイルと配線済みプレハブが同梱されているので、`.unitypackage` のインポートや sprite / インポート設定の手動変更は不要です。
  - サンプルシーンを開くか、`VRCPlayersOnlyMirror.prefab` / `VRCPlayersOnlyMirrorCutout.prefab` をシーンに配置します。
  - 透明度スライダーと ON/OFF トグルは `Runtime/` の `MirrorTransparency` および `MirrorToggleState` (UdonSharp) に既に配線済みです。スライダー値は PlayerData キー `vpom_transparency`、トグル状態は `vpom_mirror_enabled` で永続化されます。
  - 詳細は [VRChat Persistence ドキュメント](https://creators.vrchat.com/worlds/udon/persistence/) を参照してください。
  - レガシーの `MirrorTransparency 1.asset` (Udon Graph) は互換性のため残してあります。新規プロジェクトでは UdonSharp 版を使用してください。

# シェーダの種類

  - **PlayersOnlyMirror** - 透明度と距離フェード付きの通常バージョン
  - **PlayersOnlyMirrorCutout** - カットアウトのみのバリエーションで、透明度や距離フェードはありません。

# シェーダー設定

  - **Base (RBG)** - デフォルトのミラーシェーダーと同じ動作で、テクスチャを反射にオーバーレイします 
  - **Hide Background** - 背景を非表示にします。これを機能させるには、ミラーの偽の背景として機能するTransparentBackgroundシェーダーが必要です。 
  - **Ignore Effects** - パーティクルやレンズフレアなどの効果を無視しようとします。ただし、キャラクターの前にいる場合は表示されます。
  - **Transparency** - ミラーの透明度を調整します 
  - **Transparency Mask** - ミラーの透明度を調整するテクスチャマスクは、完全に不透明な白から、黒で完全に透明になります。 SDK2のミラーマテリアルプロパティをアニメーション化できないため、主にSDK2のミラー全体の透明度をリアルタイムで調整するために使用されます。 詳細については、次のセクションを参照してください。 
  - **Distance Fade** - ミラーがゼロアルファにフェードし始めるまでの距離。 0で無効になります。 
  - **Distance Fade Length** - 距離フェード長-ゼロアルファにフェードするために必要な移動距離の長さ。 
  - **Smooth Edge** - エッジをよりスムーズにし、半透明オブジェクトが不透明になる現象を軽減します。
  - **Alpha Tweak Level** - Smooth Edgeの影響度を調整します

# SDK2

VRChat SDK2 は既にサポート終了しています。リポジトリ内の SDK2 フォルダはアーカイブ専用です。 SDK3 / UdonSharp 配布を使用してください。

# 欠点

  - Smooth Edgeをオンにした場合。
    - 使用するシェーダによっては、アバターの透明マテリアルの一部が正しく透明化されない場合があります。(UTSではこの問題があります)
  - Smooth Edgeを利用しない場合、
    - ほとんどの透明な素材は鏡の中では不透明に見えます
    - 粒子、添加剤などは黒い輪郭になります
  - ミラーの後ろまたは前にある透明なマテリアルは、ミラーによって上書きまたは上書きされる可能性があります。レンダリングキューを調整すると、ステンシルを使用した最後の手段として役立ちます。

# Updates

#### v0.2.0 — 2026
  - 最新の VRChat World SDK + UdonSharp (Unity 2022.3.22f1) に対応
  - 透明度スライダーを `Runtime/MirrorTransparency.cs` (UdonSharp) で実装し、旧 Udon Graph アセットを置き換え
  - ミラートグル (`Runtime/MirrorToggleState.cs`) と透明度スライダーに PlayerData による永続化を追加。プレイヤーごとの設定がセッションをまたいで保持されます

#### 12th Sep 2022
  - Smooth Edgeトグルを追加（xiphia氏に感謝します）

#### 31st Aug 2022

  - VRCSDK3-WORLD-2022.08.29.20.48_Public では、VRCMirror でカスタム カメラ クリア フラグを設定できるため、「TransparentBackground」マスクは不要になりました。
  - SDK3のみ

#### 16th May 2021

  - シェーダーでToggleからToggleUIに変更し、使用するシェーダーキーワードを減らしました。

#### 6th Feb 2021

  - Cutoutバリアントを追加しました。このバージョンでは、ミラーの前後にある透過オブジェクトの問題は発生しないはずで、透過を必要としない場合に使用してください。  
  - 効果を無視するトグルを追加しました。パーティクル効果、レンズフレア、鏡面反射レンダリングテクスチャからゼロアルファとして読み込まれる特定の透明効果を無視しようとします。

日本語が苦手なのでGoogle翻訳を使いました。ご不便をおかけして申し訳ございません。 