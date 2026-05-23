# VRCPlayersOnlyMirror — SDK3 / UdonSharp パッケージ

背景なしでプレイヤーだけを映す VRChat ワールド用のシンプルなミラープレハブです。本ファイルは実際の配布フォルダ内のものです。完全なドキュメントは GitHub リポジトリにあります。

> English: [Readme-EN.md](Readme-EN.md)

## クイックスタート

  - Unity **2022.3.22f1** と `com.vrchat.worlds` + `com.vrchat.udonsharp` が必要です ([Creator Companion](https://vcc.docs.vrchat.com/) から導入)。
  - `Example.unity` を開くか、`VRCPlayersOnlyMirror.prefab` / `VRCPlayersOnlyMirrorCutout.prefab` をシーンに配置してください。
  - 透明度スライダーと ON/OFF トグルは `Runtime/` の UdonSharp Behaviour に事前配線済みです。手動の接続作業は不要です。
  - トグルとスライダーの状態は VRChat PlayerData でプレイヤーごとに永続化されます (デフォルトキー: `vpom_mirror_enabled`, `vpom_transparency`。同じスクリプトを複数のコントロールで使い回す場合はインスタンスごとに `persistKey` を変更してください)。

## 完全なドキュメント

リファレンス、インストール手順、変更履歴はリポジトリを参照してください:

  - **リポジトリ**: <https://github.com/acertainbluecat/VRCPlayersOnlyMirror>
  - [永続化](https://github.com/acertainbluecat/VRCPlayersOnlyMirror/blob/main/docs/persistence_JP.md)
  - [シェーダリファレンス](https://github.com/acertainbluecat/VRCPlayersOnlyMirror/blob/main/docs/shaders_JP.md) (シェーダの種類、全設定、欠点)
  - [変更履歴](https://github.com/acertainbluecat/VRCPlayersOnlyMirror/blob/main/CHANGELOG_JP.md)

レガシーの `MirrorTransparency 1.asset` (Udon Graph) は互換性のため UdonSharp 版と並行して残してあります。
