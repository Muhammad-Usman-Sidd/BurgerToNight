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
      path: '/burgers',
      name: 'burgers',
      component: ()=>import('../views/Product/BurgersView.vue')
    },
    {
      path: '/burgers/:id',
      name: 'burger',
      component: ()=>import('../views/Product/BurgerDetailsView.vue')
    },
    {
      path: '/add-burgers',
      name: 'addburgers',
      component: ()=>import('../views/Product/AddBurger.vue')
    },
    // {
    //   path: '/categories/:id',
    //   name: 'CategoryDetails',
    //   component: ()=>import('../views/Product/Caetgory.vue')
    // },
    {
      path: '/burgers/edit/:id',
      name: 'editburger',
      component: ()=>import('../views/Product/EditBurger.vue')
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
    }
  ]
})

export default router
