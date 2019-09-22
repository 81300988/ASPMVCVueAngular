var prerenderer = require('aspnet-prerendering')

module.exports = prerenderer.createServerRenderer(function(params){
    console.log(params);
    return new Promise((resolve, reject) => {
        resolve({
            html: "<h1>Hello World</h1>"
        })
    })
})