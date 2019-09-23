const path = require('path')
const VueLoaderPlugin = require('vue-loader/lib/plugin')
module.exports = {
    mode : "development",
    target: 'node',
    entry : {
        'bundle' : './vue-app/server.js'
    },
    output : {
        path : path.join(__dirname, 'wwwroot/dist'),
        filename : '[name]-server.js',
        libraryTarget: 'commonjs2',
        publicPath : '/dist/'
    },
    module : {
        rules : [
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            {
                test: /\.css$/,
                use: [
                    'vue-style-loader',
                    'css-loader'
                ]
            }
        ]
    },
    plugins:[
        new VueLoaderPlugin()
    ]
}