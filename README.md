<img width="480" height="240" alt="banner" src="https://github.com/user-attachments/assets/e144d8e4-822e-4fb5-bf9c-a6e7b88469a1" />

Quest Link 使用時のダッシュボード（OculusDash）を無効化することで、  
主に有線接続中の Meta / Oculus ヘッドセットにおいて  
SteamVR 使用時の CPU・GPU 使用率の軽減を目的としたツールです。<br><br>

以下の説明を十分にお読みのうえ、ご利用ください。

> [!IMPORTANT]
> 本ツールは Meta 社が提供・認可・サポートしている公式ツールではありません。  
> Meta 社とは一切関係のない、非公式のサードパーティ製ツールです。

> [!IMPORTANT]
> 本ツールは現在開発段階です。  
> 動作に問題が発生した場合は、作者の  
> [X アカウント](https://x.com/yurqnu) または  
> [Discord アカウント](https://discord.com/users/1080043118000361542) の DM までご報告ください。

## 対応環境
- Windows 10 / Windows 11
- Link接続が可能なMeta ヘッドセット全般
- Meta Quest Link（有線接続）
- SteamVR  

> [!IMPORTANT]
> このツールは**有線のLink接続中**にSteamVRを使用する場合に最大限の効果を発揮します。  
> 無線接続の場合は、本ツールではなく「Steam Link」を使用することをお勧めします。

> [!CAUTION]
> 本ツールはその性質上、以下の注意点があります。<br><br>
> ・本ツールは、システム設定に近い領域（アプリケーションのレジストリ設定）を変更します。  
> ・本ツールによる設定は、Meta が公式に想定・サポートしているものではありません。  
> ・「最適化モード」使用中は、Meta の PC 用メニューは使用できません。  
> ・「最適化モード」使用中は、「Meta Horizon Link」内のゲームは利用できません。  
> 本ツールは多くの場合正常に動作しますが、上記の挙動を望まない場合は使用しないでください。  
> <ins>**本ツールの使用によって発生したいかなる損害についても、作者は責任を負いかねます。**</ins><br><br>
> （作者はコンピュータに関する一定の知識を有し、動作確認も行っていますが、  
> 万が一の事態を考慮し、あらかじめ注意喚起を行っています。）

> [!NOTE]
> 本ツールによる変更は恒久的なものではありません。  
> 「通常モード」に戻すことで、設定は元の状態に復元されます。  
> 動作に問題が発生した場合は、「通常モード」に戻したうえで  
> Meta App を再起動してください。
> それでも解消しない場合は[お問い合わせ](#お問い合わせ)へ。

> [!NOTE]
> 本ツールの動作内容は以下の通りです。（上級者向け）<br><br>
> 1. Meta App の特定のレジストリを書き換えます。  
> （`HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Oculus VR, LLC\Oculus\Config` 内に  
>  `PreventDashLaunch` を作成し、値を 0 ⇔ 1 に変更します）  
> 2. Meta App のサービスを再起動します。  
> （サービス `OVRService` の停止および起動）


## インストール・実行方法
1. [リリースページ](https://github.com/YuranuDev/MetaOptimizer/releases/latest)より、ツールをダウンロードします。  
<img width="400" alt="image" src="https://github.com/user-attachments/assets/f2c71f7d-777f-4c1f-9693-7d44a6aff15c" />

2. 任意のフォルダーに解凍し、`MetaOptimizer` または `MetaOptimizer.exe` を実行します。  
<img width="163" height="39" alt="image" src="https://github.com/user-attachments/assets/7327ca41-6232-4717-8a85-1460ca68e31b" />
<img width="159" height="38" alt="image" src="https://github.com/user-attachments/assets/fcbda79b-d35c-4706-82c4-0aecb4d7d644" />

## 使用方法
・起動すると以下のようなウィンドウが表示されます。  
<img width="342" height="192" alt="image" src="https://github.com/user-attachments/assets/499d63fb-97f1-4704-827e-cb4f9c0960d2" />

① 通常モードボタン: MetaのPC内メニューをオンにします。(デフォルトの状態)  
② 最適化モードボタン: MetaのPC内メニューをオフにして、軽量化します。  
③ ステータス: ツールの処理内容が表示されます。  
④ サービスステータス: Link接続時に使用されるサービスの起動状態が表示されます。  

・SteamVRとLink接続を同時に使用する場合は「最適化モード」を使用してください。  
・SteamVRを使用しない場合、MetaのPC内メニューを使用したい場合は必ず「通常モード」を使用してください。  

> [!IMPORTANT]
> 本ツールは Meta の PC 用メニューを無効化します。  
> そのため、Link 接続時に使用できるメニュー画面が表示されず、  
> SteamVR を起動しない場合、Link 接続時の VR が正常に動作しません。  
> 通常のメニューを使用したい場合は、<ins>**必ず「通常モード」に戻してください。**</ins>

> [!CAUTION]
> ・「最適化モード」使用中は、Meta の PC 用メニューは使用できません。  
> ・「最適化モード」使用中は、「Meta Horizon Link」内のゲームは利用できません。

> [!Tip]
> ・モード変更時はLink接続を一時的に切断することをお勧めします。  
> ・モードを変更すると「Meta Horizon Link」が終了します。  
> ・モードを変更した際は、再び「Meta Horizon Link」を起動することをお勧めします。

## お問い合わせ
・作者の[X アカウント](https://x.com/yurqnu)  
・作者の[Discord アカウント](https://discord.com/users/1080043118000361542)  

