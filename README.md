KORG nanoKONTROL2 Setup Tool For Unity
-------

<img src="https://user-images.githubusercontent.com/15060080/210543288-45508b9e-0784-4f06-b6e1-e76c017e96fc.gif" width="300">

KORG nanoKONTROL2をUnityで使用するためのセットアップツールです。

Dependency
-------

このツールを使用するには、[Input System](https://forpro.unity3d.jp/unity_pro_tips/2021/05/20/1957/)、[Minis](https://github.com/keijiro/Minis)、[UniRx](https://assetstore.unity.com/packages/tools/integration/unirx-reactive-extensions-for-unity-17276)をプロジェクトにインポートする必要があります。

以下の環境でテスト済みです。
<table>
  <thead>
    <tr>
      <th>name</th> <th>version</th>
    </tr>
  </thead>
  <tr>
    <td> Unity </td> <td>2021.3.10f1</td>
  </tr>
  <tr>
    <td> Input System </td> <td>1.4.1</td>
  </tr>
  <tr>
    <td> Minis </td> <td>1.0.10</td>
  </tr>
  <tr>
    <td> UniRx </td> <td>7.1.0</td>
  </tr>
</table>

Usage
-------
### Set up

必要なパッケージをインポートしたら、[こちら](https://github.com/W0NYV/nanokon2-setup/releases/tag/v0-0-1)のUnityPackageもインポートします。

Project Settings -> Player -> Other Settings -> ConfigurationのActive Input HandlingをBothに設定します。
![image](https://user-images.githubusercontent.com/15060080/210549116-047e1931-5fc9-48ab-bddb-787926001dd3.png)

nanokon2-setupフォルダ -> Prefabsフォルダに入っているnanoKONTROL2.prefabを任意のシーンに置き、
nanoKONTROL2をPCに接続し、実行すると動きます。

### Event Subscription

nanoKONTROL2から信号を受け取り、メソッドを実行したい時は、nanokon2-setupフォルダ -> Scriptsフォルダに入っている
NanoKON2EventSubscriberコンポーネントを追加します。

![image](https://user-images.githubusercontent.com/15060080/210551357-eff10c0b-3871-4734-9d3e-9377b5b0a237.png)

Inspectorで実行したいメソッド、コントローラの種類、コントローラの番号を指定します。  
メソッドのfloat型の引数を用意しておくと、値を受け取ることができます(範囲は0~1)。

<img src="https://user-images.githubusercontent.com/15060080/210552030-d97443f5-64f3-43a1-8375-7eee71f95e57.png" width="200">

※Dynamic floatの方を選ばないと、値を受け取れません。

コントローラの種類と番号は以下のようになっています。
![nano2](https://user-images.githubusercontent.com/15060080/210558725-2fe7d961-2586-4415-bc13-184c5a3ab4fa.png)

