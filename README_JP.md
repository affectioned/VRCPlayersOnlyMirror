# VRCPlayersOnlyMirror

素敵な地図で景色を眺めるか、自分の反射を見つめるかを選択するのにうんざりしていませんか？ 今、あなたは両方を同時に行うことができます！
VRCPlayersOnlyMirrorは、背景のないプレーヤーのみを表示するシンプルなミラーprefabです。
これは切り抜かれた2Dカメラではなく、完全な3Dミラーです。

  - 背景のない鏡でのプレイヤーの反射
  - 調整可能なミラーの透明度
  - 単純な距離フェード
  - PCとQuestの両方の世界で動作します
  - LQミラーとほぼ同等の性能コスト

# v0.2.0 — 最新の VRChat World SDK に対応

  - VPM パッケージとして配布 (Creator Companion 対応)
  - Udon Graph スクリプトを [UdonSharp](https://udonsharp.docs.vrchat.com/) (`Runtime/MirrorTransparency.cs`) に移行。レガシー Graph アセットも SDK3 フォルダ内に互換性のため残してあります
  - ミラートグル・透明度スライダーをプレイヤーごとに [Persistence](https://creators.vrchat.com/worlds/udon/persistence/) で保存 — セッションやインスタンスをまたいで設定が引き継がれます
  - [VRChat が現在サポートする Unity バージョン (2022.3.22f1)](https://creators.vrchat.com/sdk/upgrade/current-unity-version) に追従
  - SDK2 は VRChat 側で既にサポート終了。`VRCPlayersOnlyMirrorSDK2` フォルダはアーカイブ用途として残しています

# 要件

  - Unity **2022.3.22f1** ([VRChat 現行サポート Unity バージョン](https://creators.vrchat.com/sdk/upgrade/current-unity-version))
  - [VRChat Creator Companion](https://vcc.docs.vrchat.com/) (VCC)
  - VPM パッケージ (VCC が自動でインストール):
    - `com.vrchat.worlds` — 最新の VRChat World SDK
    - `com.vrchat.udonsharp` — UdonSharp

Udon の概要、Udon Graph と UdonSharp の違いについては [VRChat Udon ドキュメント](https://creators.vrchat.com/worlds/udon/) を参照してください。

# インストール

## オプション A — VCC / Creator Companion (推奨)

1. [VRChat Creator Companion](https://vcc.docs.vrchat.com/) をインストールします。
2. 新規 **World** プロジェクトを作成すると、VCC が `com.vrchat.worlds` と対応する Unity バージョンを自動で取得します。
3. VCC のパッケージ一覧から `com.vrchat.udonsharp` をプロジェクトに追加します。
4. `VRCPlayersOnlyMirrorSDK3/Assets/VRCPlayersOnlyMirror` フォルダをプロジェクトの `Assets/` にコピー (またはリリースの `.unitypackage` をインポート) します。

## オプション B — .unitypackage (従来配布)

  - [Releases](https://github.com/acertainbluecat/VRCPlayersOnlyMirror/releases) からダウンロードできます。SDK3 パッケージは最新の VRChat World SDK + UdonSharp 向けです。

## SDK2 (アーカイブのみ)

VRChat は SDK2 を数年前にサポート終了しています。`VRCPlayersOnlyMirrorSDK2/` フォルダは歴史的な参考用に残してあり、**現行の VRChat ワールドでは動作しません**。SDK3 パッケージを使用してください。

# 使い方

  - サンプルシーン (`Assets/VRCPlayersOnlyMirror/Example.unity`) を開くか、`VRCPlayersOnlyMirror.prefab` / `VRCPlayersOnlyMirrorCutout.prefab` をシーンに配置してください。
  - プレハブの `Mirror` GameObject には `VRC_MirrorReflection` が設定済みで、`cameraClearFlags = SolidColor` + 透明クリアカラー + PlayersOnlyMirror シェーダの構成になっています。 `TransparentBackground` マスクは不要です。
  - 透明度スライダーを使う場合は、`Mirror` GameObject の UdonBehaviour に `MirrorTransparency` (UdonSharp) コンポーネントを取り付け、以下を割り当ててください:
    - `uiSlider` → `TransparencySlider` の Slider
    - `Mirror` → `Mirror` の MeshRenderer
  - ON/OFF トグルには `MirrorToggleState` を `MirrorToggle` GameObject に取り付け、以下を割り当ててください:
    - `mirrorToggle` → `MirrorToggle` の `Toggle` コンポーネント
    - `targets` → `Mirror` と `TransparencySlider` の GameObject
    - `Toggle.OnValueChanged` 側にあった `SetActive` の Persistent Call を削除し、代わりに `MirrorToggleState.OnToggleChanged` を 1 つだけ登録してください (こうしないと状態が保存されません)。

# Persistence (永続化)

サンプルプレハブは [VRChat PlayerData](https://creators.vrchat.com/worlds/udon/persistence/) を使い、UI の状態を **ワールド・プレイヤーごと** に保存します。サーバーや独自 DB は不要で、VRChat 側に保存されます。

| キー                    | 型     | 設定元                | 保存する内容                |
|------------------------|--------|-----------------------|-----------------------------|
| `vpom_mirror_enabled`  | bool   | `MirrorToggleState`   | ミラーの ON/OFF             |
| `vpom_transparency`    | float  | `MirrorTransparency`  | 透明度スライダーの値        |

どちらの UdonSharp スクリプトも `OnPlayerRestored` (PlayerData が利用可能になる安全なタイミング) でデータを読み込み、ローカルプレイヤー分だけを保存します。インスペクタの `persist` チェックボックスを外せば永続化を無効化できます。

ワールドあたり 1 プレイヤー 100KB まで保存可能で、本プレハブの使用量はおよそ 16 バイトです。

  「VRC Mirror Reflection」コンポーネントは、ミラーに背景が残っている場合、次のように表示されることを確認してください。
  ![vrcmirrorreflection](https://cdn.nyanpa.su/i/PiMX2EB0.jpg)

# シェーダの種類

  - **PlayersOnlyMirror** - 透明度と距離フェード付きの通常バージョン
  - **PlayersOnlyMirrorCutout** - カットアウトのみのバリエーションで、透明度や距離フェードはありません。

# シェーダー設定

  - **Base (RBG)** - デフォルトのミラーシェーダーと同じ動作で、テクスチャを反射にオーバーレイします
  - **Hide Background** - 背景を非表示にします。これを機能させるには、ミラーの偽の背景として機能するTransparentBackgroundシェーダーが必要です。
  - **Ignore Effects** - パーティクルやレンズフレアなどの効果を無視しようとします。ただし、キャラクターの前にいる場合は表示されます。
  - **Transparency** - ミラーの透明度を調整します
  - **Transparency Mask** - ミラーの透明度を調整するテクスチャマスクは、完全に不透明な白から、黒で完全に透明になります。
  - **Distance Fade** - ミラーがゼロアルファにフェードし始めるまでの距離。 0で無効になります。
  - **Distance Fade Length** - 距離フェード長-ゼロアルファにフェードするために必要な移動距離の長さ。
  - **Smooth Edge** - エッジをよりスムーズにし、半透明オブジェクトが不透明になる現象を軽減します。
  - **Alpha Tweak Level** - Smooth Edgeの影響度を調整します

# 欠点

  - Smooth Edgeをオンにした場合。
    - 使用するシェーダによっては、アバターの透明マテリアルの一部が正しく透明化されない場合があります。(UTSではこの問題があります)
  - Smooth Edgeを利用しない場合、
    - ほとんどの透明な素材は鏡の中では不透明に見えます
    - 粒子、添加剤などは黒い輪郭になります
  - ミラーの後ろまたは前にある透明なマテリアルは、ミラーによって上書きまたは上書きされる可能性があります。レンダリングキューを調整すると、ステンシルを使用した最後の手段として役立ちます。

# Updates

#### v0.2.0 — 2026
  - 最新の VRChat World SDK + Unity 2022.3.22f1 に対応
  - 透明度スライダーの Udon Graph を UdonSharp に移行
  - SDK3 フォルダを VCC で取り込めるよう VPM `package.json` を追加
  - SDK2 配布をアーカイブ専用としてマーク (VRChat 側で SDK2 サポート終了済)
  - ミラートグル (`MirrorToggleState`) と透明度スライダー (`MirrorTransparency`) を VRChat PlayerData で永続化 — プレイヤーごとの設定がセッションをまたいで保持されます

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

# Demo

この鏡が実際に動いているのを見たい場合は、私の公開地図の一つ、Winter Solaceで見つけることができます。
https://vrchat.com/home/world/wrld_8899947f-8e19-4981-b327-a63be233706a

![demo1](https://nyanpa.su/i/MKH21bPq.jpg)
![demo2](https://nyanpa.su/i/gEzZ1bQD.jpg)
