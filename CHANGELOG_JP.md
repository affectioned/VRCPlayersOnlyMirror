# 変更履歴

## v0.2.0 — 2026

  - 最新の VRChat World SDK + Unity 2022.3.22f1 に対応
  - 透明度スライダーの Udon Graph を UdonSharp に移行
  - VPM リスティング配信用に `package.json` を整備 (リスティング公開後 VCC から導入可能)
  - SDK2 配布をアーカイブ専用としてマーク (VRChat 側で SDK2 サポート終了済)
  - ミラートグル (`MirrorToggleState`) と透明度スライダー (`MirrorTransparency`) を VRChat PlayerData で永続化 — プレイヤーごとの設定がセッションをまたいで保持されます
  - `persistKey` をインスペクタの公開フィールドに変更。同一ワールド内で複数のトグル / スライダーを使い回しても PlayerData のキーが衝突しないように構成可能
  - `PlayersOnlyMirror.shader` の Distance Fade が初期化されていない補間値と座標空間のずれた値を比較していた不具合を修正。`Distance Fade` スライダーを 0 より上げた瞬間から正しくフェードします
  - 両シェーダに `#pragma multi_compile_instancing` を追加し、複数ミラーを GPU バッチ可能に (SPS-I のステレオ対応マクロは元から正しく入っていました)
  - Unity `.meta` をリポジトリで管理し、プレハブを配線済みの状態でコミット。これによりフォルダのインポートに `.unitypackage` も手動の sprite/インポート設定変更も不要になりました

## 12th Sep 2022
  - Smooth Edgeトグルを追加（xiphia氏に感謝します）

## 31st Aug 2022
  - VRCSDK3-WORLD-2022.08.29.20.48_Public では、VRCMirror でカスタム カメラ クリア フラグを設定できるため、「TransparentBackground」マスクは不要になりました。
  - SDK3のみ

## 16th May 2021
  - シェーダーでToggleからToggleUIに変更し、使用するシェーダーキーワードを減らしました。

## 6th Feb 2021
  - Cutoutバリアントを追加しました。このバージョンでは、ミラーの前後にある透過オブジェクトの問題は発生しないはずで、透過を必要としない場合に使用してください。
  - 効果を無視するトグルを追加しました。パーティクル効果、レンズフレア、鏡面反射レンダリングテクスチャからゼロアルファとして読み込まれる特定の透明効果を無視しようとします。
