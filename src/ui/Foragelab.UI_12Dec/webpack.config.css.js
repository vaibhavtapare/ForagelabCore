const path = require('path');
const ExtractTextPlugin = require('extract-text-webpack-plugin');

module.exports = (env) => {

    const extractSass = new ExtractTextPlugin({
        filename: "main.css",
        disable: env === "development"
    });

    const clientBundleOutputDir = './wwwroot/dist';
    const cssBundleConfig = {
        entry: {
            styles: [
                './ClientApp/app/assets/styles/main.scss',
                './node_modules/font-awesome/scss/font-awesome.scss'
            ]
        },
        output: {
            path: path.join(__dirname, clientBundleOutputDir),
            filename: 'styles.js'
        },
        module: {
            rules: [
                {
                    test: /\.scss$/,
                    use: extractSass.extract({
                        use: [{
                            loader: "css-loader"
                        }, {
                            loader: "sass-loader"
                        }],
                        // use style-loader in development
                        fallback: "style-loader"
                    })
                },
                {
                    test: /.(png|jpg|jpeg|gif|svg|woff|woff2|ttf|eot)$/,
                    use: 'url-loader?limit=10000'
                }
            ]
        },
        plugins: [
            extractSass
        ]
    };

    return [cssBundleConfig];
}
