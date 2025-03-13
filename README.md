# Conversor de Imagem em "Imagem Linha"

## Descrição

Este é um projeto de estudo desenvolvido para ser executado via linha de comando (CLI) ou diretamente pela IDE de desenvolvimento. O objetivo é carregar uma imagem, processar seus pixels e gerar uma nova imagem composta por formas geométricas do tipo "Elipse".
Assim com uma imagem é formada por pixels coloridos, a nossa imagem será formada por conjuntos de linhas.
Para facilitar a compreensão, utilizaremos o termo "PixelLinhas".
É conhecido como **"halftone"**.

## Requisitos

- .NET 6 ou superior
- Biblioteca:
    - SixLabors.ImageSharp (para manipulação de imagens)

## Instalação

```bash
dotnet add package SixLabors.ImageSharp
```

## Funcionalidades

- Suporte a formatos comuns de imagem: JPEG, PNG, BMP, GIF, TIFF.
- Leitura e processamento dos pixels da imagem, criando uma matriz de dados.
- Conversão da luminosidade em "PixelLinhas" para formar a nova imagem.
- Geração de um arquivo `.jpg`.
- Possibilidade de configurar diferentes métodos de cálculo de luminosidade.


## Como Funciona

1. A imagem é carregada e convertida em uma matriz contendo suas informações.
2. Cada pixel, ou conjunto de pixels, tem sua luminosidade calculada e convertida em uma coordenada.
3. A matriz é processada e, para cada coordenada, um "PixelLinhas" é desenhado na nova imagem.
4. O resultado é salvo em um arquivo `.jpg`.

### Configurações

#### Resolução
- Definição da resolução em percentual, determinando a nitidez da imagem final.
- Exemplo:
    - **100%** significa que cada pixel original será convertido em um "PixelLinhas".
    - **50%** significa que será analisado um conjunto de 2 x 2 pixels, realizada uma media de luminosidade para gerar um "PixelLinhas".
    - **20%** significa que será analisado um conjunto de 5 x 5 pixels, realizada uma media de luminosidade para gerar um "PixelLinhas".

#### Saturação
- Ajuste de saturação para aumentar ou diminuir a intensidade do "PixelLinhas".

#### Tamanho do Pixel
- Influencia diretamente no tamanho e qualidade final da imagem.

#### Intercalação
- É um valor adicional ao "Tamanho do Pixel", serve para suavisar a imagem final sem perceber os "PixelLinhas".

## Estrutura do Código

### `Matriz.cs`
Responsável por armazenar estrutura da imagem em coordenadas. Cada coordenada será um "PixelsElipse". Ela contém:

- **X**: Posição horizontal do pixel.
- **Y**: Posição vertical do pixel.
- **Luminosidade**: Intensidade da luz do pixel.

### `Controlador.cs`
Responsável analisar os pixels da imagem conforme a resolução.

### `ImageConverter.cs`
Responsável por receber a imagem e convertê-la em uma matriz de dados.

### `PixelConverter.cs`
Responsável por extrair a luminosidade da imagem e convertê-la em um valor numérico.

### Classes de Luminosidade
O cálculo da luminosidade pode ser ajustado utilizando diferentes métodos. O padrão mais comum é `Luminosidade_R21_G71_B07`, baseado na percepção humana:

- **21%** Vermelho (R * 0.21)
- **71%** Verde (G * 0.71)
- **07%** Azul (B * 0.07)

## Uso

### Execução via IDE
Abra o projeto na IDE, defina o caminho da imagem e a resolução desejada. O arquivo convertido será salvo na pasta raiz do projeto.
O arquivo convertido será salvo automaticamente no diretório do projeto.

## Considerações

- Para obter melhores resultados, comece com uma resolução baixa (exemplo: 10%) e aumente progressivamente.
- Ajuste a resolução e o tamanho do pixel conforme necessário para obter um nível adequado de detalhes.

## Exemplo de Saída

- **Imagem com 100% de resolução**, Saturação 0.2, Tamanho de pixel 10. Tamanho final: **6.06MB** Resolução final **2890x2680**
  ![Imagem com 50% de resolução](ImagemGerada-resolucao100.jpg)

- **Imagem com 50% de resolução**, Saturação 0.5, Tamanho de pixel 20. Tamanho final: **6.69MB** Resolução final **2900x2700**
  ![Imagem com 80% de resolução](ImagemGerada-resolucao50.jpg)
