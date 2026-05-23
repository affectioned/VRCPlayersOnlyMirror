# Persistence (永続化)

サンプルプレハブは [VRChat PlayerData](https://creators.vrchat.com/worlds/udon/persistence/) を使い、UI の状態を **ワールド・プレイヤーごと** に保存します。サーバーや独自 DB は不要で、VRChat 側に保存されます。

## デフォルトキー

| デフォルトキー          | 型     | 設定元                | 保存する内容                |
|------------------------|--------|-----------------------|-----------------------------|
| `vpom_mirror_enabled`  | bool   | `MirrorToggleState`   | ミラーの ON/OFF             |
| `vpom_transparency`    | float  | `MirrorTransparency`  | 透明度スライダーの値        |

## 動作仕組み

どちらの UdonSharp スクリプトも `OnPlayerRestored` (PlayerData が利用可能になる安全なタイミング) でデータを読み込み、ローカルプレイヤー分だけを保存します。インスペクタで以下 2 つのフィールドを公開しています:

  - `persist` — コンポーネント単位で PlayerData の読み書きを無効化するチェックボックス。
  - `persistKey` — PlayerData のスロット名。同一ワールド内で複数のトグル / スライダーに使い回す場合はインスタンスごとに別のキーを指定してください。空欄にすると永続化が無効になります (`persist` を外す代わりにも使えます)。

## 容量

ワールドあたり 1 プレイヤー 100KB まで保存可能で、本プレハブの使用量はおよそ 16 バイトです。
