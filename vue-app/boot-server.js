const prerenderer = require('aspnet-prerendering');

const vueRenderer = require('vue-server-renderer');
const path = require('path')
const filePath = path.join(__dirname,'../wwwroot/dist/bundle-server.js')

const bundleRenderer= vueRenderer.createBundleRenderer(filePath)
module.exports = prerenderer.createServerRenderer(function(params){
    const context = {
        url: params.url,
        origin: params.origin
    }
    return new Promise((resolve, reject) => {
        bundleRenderer.renderToString(context, function(err, html){
            if(err){
                reject(err);
            }
            resolve({
                html
            })
        })
    })
})