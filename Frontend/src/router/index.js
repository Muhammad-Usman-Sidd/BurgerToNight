import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: ()=>import('../views/HomeView.vue')
    },
    {
      path: '/products',
      name: 'products',
      component: ()=>import('../views/Product/ProductsView.vue')
    },
    {
      path: '/products/:id',
      name: 'product',
      component: ()=>import('../views/Product/ProductDetailsView.vue')
    },
    {
      path: '/add-products',
      name: 'addproducts',
      component: ()=>import('../views/Product/AddProduct.vue')
    },
    // {
    //   path: '/categories/:id',
    //   name: 'CategoryDetails',
    //   component: ()=>import('../views/Product/Caetgory.vue')
    // },
    {
      path: '/products/edit/:id',
      name: 'editproduct',
      component: ()=>import('../views/Product/EditProduct.vue')
    },
    {
      path: '/categories',
      name: 'categories',
      component: ()=>import('../views/Category/Categories.vue')
    },
    {
      path: '/add-categories',
      name: 'add-categories',
      component: ()=>import('../views/Category/AddCategory.vue')
    },
    {
      path: '/categories/edit/:id',
      name: 'editcategory',
      component: ()=>import('../views/Category/EditCategory.vue')
    },
    {
      path: '/past-orders',
      name: 'pastorders',
      component: ()=>import('../views/Orders/PastOrders.vue')
    }, 
    {
      path: '/orders',
      name: 'orders',
      component: ()=>import('../views/Orders/ManageOrders.vue')
    },
    {
      path: '/order-confirmation',
      name: 'order-confirmation',
      component: ()=>import('../components/CheckoutPage.vue')
    },
     
    {
      path: '/register',
      name: 'register',
      component: ()=>import('../views/Auth/Registration.vue')
    },
    {
      path: '/login',
      name: 'login',
      component: ()=>import('../views/Auth/Login.vue')
    },
    {
      path: '/reset-password',
      name: 'resetPassword',
      component: ()=>import('../views/Auth/ResetPassword.vue')
    },
    {
      path: '/:pathMatch(.*)*', // Catch-all route
      name: 'NotFound',
      component: ()=>import('../components/404.vue'),
    }  
  ]
})

export default router
