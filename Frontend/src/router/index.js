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
      name: 'addburger',
      component: ()=>import('../views/Product/AddBurger.vue')
    },
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
      path: '/past-orders',
      name: 'pastorders',
      component: ()=>import('../views/PastOrders.vue')
    }
    // {
    //   path: '/categories/:id',
    //   name: 'categories',
    //   component: ()=>import('../views/CategoriesDetails.vue')
    // }
  ]
})

export default router
