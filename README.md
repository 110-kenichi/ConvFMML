# ConvFMML
MIDI→MML Converter  
Copyright (C) 2017 Rerrah

## 概要
ConvFMMLはスタンダードMIDIファイル(SMF/MIDI)をミュージックマクロランゲージ(MML)形式に変換するソフトです。  
以下のような処理が可能です。  

* MIDIデータから自動で音符・休符を生成(和音対応)
* MMLデータをFMP7、FMP、PMD、MXDRV、NRTDRV、カスタムのうち指定されたMML書式で出力
* 小節ごとに音符・休符を改行・ブロック分け
* MIDIデータの音量、パンのコントロールチェンジ(CC)、プログラムチェンジ(PC)、テンポをMML出力
* 出力するMIDIトラックの指定・MMLパート名指定

より詳細な変換指定は「変換設定」で指定できます。

### MIDIファイルの読み込み
変換するMIDIファイルをConvFMMLにドラッグ&ドロップするか、「変換MIDI」の欄にある「参照」ボタンをクリックして選択してください。

### 変換・MMLの出力
「出力MML」欄の「変換」ボタンを押すと、出力MML名設定ダイアログが開きます。  
ここで出力MMLの名前、ファイル拡張子を指定します。  
「保存」ボタンを押すと変換・MML出力が開始されます。

### 変換設定
「変換設定」では出力するMMLコマンドの最適化、音符・休符の表示形式、小節によるブロック分け、出力するMMLパートの指定などを行うことができます。  
左側のツリービューで項目を選択すると、右側の各設定画面が切り替わります。

#### MML表現メニュー
出力するMMLの書式や分解能の設定、小節ごとのブロック分けや拍子変更による改行の設定を行うことができます。

ConvFMMLでは、MML書式設定によってタイ、音量、パン、テンポなどのMMLコマンドをそれぞれのMML形式のものに自動で設定します。  
カスタム書式指定ではこれらのコマンド表記をそれぞれ指定することができます。  
また、MML書式設定によって指定できる変換設定が限定されます。

#### 音符・休符メニュー
音符・休符の出力に関係した設定を行うことができます。  
オクターブコマンドの表示設定、音符・休符の音長表記設定などを行うことができます。
　　
#### 各種コマンドメニュー
メニューは「全体設定」、「音量」、「パン」、「プログラムチェンジ」、「テンポ」の5つに分かれています。  
「全体設定」メニューでは音量、パン、プログラムチェンジ、テンポの共通する変換設定・最適化設定を行なうことができます。  
「音量」メニューではMML出力する音量コマンドの設定を行うことができます。  
「パン」メニューではMML出力するパンコマンドの設定を行うことができます。  
「プログラムチェンジ」メニューではMML出力するプログラムチェンジコマンドの設定を行うことができます。  
「テンポ」メニューではMML出力する音量コマンドの設定を行うことができます。

### 出力パートメニュー
読み込んだMIDIトラックのうち、MMLとして出力するパートの設定やそのパートの名前、使用音源の設定を行うことができます。

出力パート・パート名・音源指定では、MML出力するパートをチェックをして指定します。  
出力しないパートは灰色で、パート数の関係上出力できないパートは赤色で表示されます。  
赤いパートが表示されている場合でもMML出力は可能ですが、コマンドなどが正しく出力されない可能性があります。  
MIDIトラック中に音符が2音以上同時発音する箇所がある場合、MIDIトラックナンバーとMIDIトラック名が同じものが複数表示されます。  
これらは同時発音している音符を各パートに分解したものです。

### その他
MIDIでの和音の構成数だけMMLパート数が増えます。

MIDIの調号指定によってMMLの音符の音階表記を変更することが可能です。

MIDIファイルに拍子・テンポ・調号設定がされていない場合は、ConvFMMLでの規定値を使用して処理します。  
なお、規定値は4/4拍子、120bpm、ハ長調です。

MMLの分解能で表現できない長さの音符・休符は自動的に削除されます。  
MMLの分解能が高くなるほど変換精度は向上しますが、より細かい音符が出現します。

各種コマンドの最適化処理は、

1. 音符に影響を及ぼさないものの処理
2. 同位置同種のものの処理
3. 同種同値(宣言済み)のものの処理

の順番で行います。  
場合によっては適切に処理されないコマンドが残ることがあります。

## 動作環境
* Windows (Windows 10では確認済み)
* .NET Framework 4.6以降がインストールされている環境

## 著作権/ライセンス
本ソフトの著作権はRerrahが所有します。  
本ソフトのライセンスはMIT Licenseです。