import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia';
import App from './App.vue'
import router from './router'
import Toast from 'vue-toastification'
import 'vue-toastification/dist/index.css'

const app = createApp(App)
const pinia = createPinia();

app.use(router)
app.use(Toast)
app.use(pinia);


app.mount('#app')
