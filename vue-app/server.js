import {createApp} from './main'


export default function(context){
    const {app, router, store} = createApp();
    
    return new Promise((resolve, reject) => {
        const {url, origin} = context;
        router.push(url);
        router.onReady(() => {
            store.dispatch('loadBlogs', origin)
            .then(() => {
                resolve(app);
            })
        })
    })
}