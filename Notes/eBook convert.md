## eBook convert

* This is a [node.js](https://nodejs.org/en/) module and you can download this module with ```npm```:

  ``` 
  npm install ebook-convert
  ```

* Based on the introduction on ```npm```, "this is a wrapper around the command-line tool *ebook-convert* from Calibre". I am not very sure if you have to [install calibre](https://calibre-ebook.com/download) as a dependency.

* If everything work well, you can use the module in .js file:

  ``` js
  var path = require('path')
  var xtend = require('xtend')
  var convert = require('ebook-convert')
   
  // see more options at https://manual.calibre-ebook.com/generated/en/ebook-convert.html
  var options = {
    input: '"'+path.join(__dirname, 'Metamorphosis-jackson.mobi')+'"', 
    output: '"'+path.join(__dirname, 'Metamorphosis-jackson.epub')+'"',
    authors: '"Seth Vincent"',
    pageBreaksBefore: '//h:h1',
    chapter: '//h:h1',
    insertBlankLine: true,
    insertBlankLineSize: '1',
    lineHeight: '12',
    marginTop: '50',
    marginRight: '50',
    marginBottom: '50',
    marginLeft: '50'
  }
   
  /*
  * create epub file
  */
  convert(options, function (err) {
    if (err) console.log(err)
  })
  ```

* And you can use it in command line interface, a ref is [here](https://manual.calibre-ebook.com/generated/en/ebook-convert.html):

  ``` shell
  ebook-convert input_file output_file [options]
  ```

  