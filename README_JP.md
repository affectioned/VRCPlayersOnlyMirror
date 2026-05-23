# VRCPlayersOnlyMirror

素敵な地図で景色を眺めるか、自分の反射を見つめるかを選択するのにうんざりしていませんか？ 今、あなたは両方を同時に行うことができます！
VRCPlayersOnlyMirrorは、背景のないプレーヤーのみを表示するシンプルなミラーprefabです。
これは切り抜かれた2Dカメラではなく、完全な3Dミラーです。

  - 背景のない鏡でのプレイヤーの反射
  - 調整可能なミラーの透明度
  - 単純な距離フェード
  - PCとQuestの両方の世界で動作します
  - LQミラーとほぼ同等の性能コスト
  - トグル / スライダーの状態を VRChat PlayerData でプレイヤーごとに [永続化](docs/persistence_JP.md)

> English: [README.md](README.md)

# 要件

  - Unity **2022.3.22f1** ([VRChat 現行サポート Unity バージョン](https://creators.vrchat.com/sdk/upgrade/current-unity-version))
  - [VRChat Creator Companion](https://vcc.docs.vrchat.com/) (VCC)
  - VPM パッケージ (VCC が自動でインストール):
    - `com.vrchat.worlds` — 最新の VRChat World SDK
    - `com.vrchat.udonsharp` — UdonSharp

Udon の概要、Udon Graph と UdonSharp の違いについては [VRChat Udon ドキュメント](https://creators.vrchat.com/worlds/udon/) を参照してください。

# インストール

SDK3 フォルダは完全に自己完結しています — `.meta` ファイル、プレハブの配線、UdonSharp プログラムアセット、テクスチャのインポート設定、VPM `package.json` すべてがコミットされています。ワークフローに合った方法を選んでください:

## オプション A — フォルダを直接コピー (現時点で利用可能)

1. [VRChat Creator Companion](https://vcc.docs.vrchat.com/) で **World** プロジェクトを作成し、VCC のパッケージ一覧から `com.vrchat.udonsharp` を追加します。`com.vrchat.worlds` と対応する Unity バージョンは VCC が自動で取得します。
2. 本リポジトリを ZIP でダウンロード、または `git clone` してから `VRCPlayersOnlyMirrorSDK3/Assets/VRCPlayersOnlyMirror` フォルダをプロジェクトの `Assets/` にコピーするだけです。コミット済みの `.meta` を Unity が読み込み、プレハブ参照やインポート設定は自動で解決されます (手動操作不要)。

## オプション B — .unitypackage

ワンファイルでドラッグ&ドロップで導入したい方向けに、ビルド済み `.unitypackage` を [Releases](https://github.com/acertainbluecat/VRCPlayersOnlyMirror/releases) に添付しています。

## オプション C — VCC / VPM リスティング (公開後)

`VRCPlayersOnlyMirrorSDK3/package.json` は VPM リスティング経由で配信し、Creator Companion から直接インストールできるように構成されています。VPM リスティングのインデックスを公開するかどうかはリポジトリの作者に委ねられています。リスティングが公開されるまでは、オプション A または B をご利用ください。

## SDK2 (アーカイブのみ)

VRChat は SDK2 を数年前にサポート終了しています。`VRCPlayersOnlyMirrorSDK2/` フォルダは歴史的な参考用に残してあり、**現行の VRChat ワールドでは動作しません**。SDK3 パッケージを使用してください。

# 使い方

  - サンプルシーン (`Assets/VRCPlayersOnlyMirror/Example.unity`) を開くか、`VRCPlayersOnlyMirror.prefab` / `VRCPlayersOnlyMirrorCutout.prefab` をシーンに配置してください。
  - プレハブの `Mirror` GameObject には `VRC_MirrorReflection` が設定済みで、`cameraClearFlags = SolidColor` + 透明クリアカラー + PlayersOnlyMirror シェーダの構成になっています。 `TransparentBackground` マスクは不要です。
  - 透明度スライダーと ON/OFF トグルは `MirrorTransparency` および `MirrorToggleState` (UdonSharp) に事前配線済みです。手動での接続作業は不要です。

# ドキュメント

  - [永続化](docs/persistence_JP.md) — PlayerData キー、`persist` / `persistKey` インスペクタフィールド、複数のトグルやスライダーへの再利用方法。
  - [シェーダリファレンス](docs/shaders_JP.md) — シェーダの種類、全シェーダー設定、欠点、`VRC_MirrorReflection` の設定スクリーンショット。
  - [変更履歴](CHANGELOG_JP.md) — リリース全履歴。

# Demo

この鏡が実際に動いているのを見たい場合は、私の公開地図の一つ、Winter Solaceで見つけることができます。
https://vrchat.com/home/world/wrld_8899947f-8e19-4981-b327-a63be233706a

![demo1](https://nyanpa.su/i/MKH21bPq.jpg)
![demo2](https://nyanpa.su/i/gEzZ1bQD.jpg)
