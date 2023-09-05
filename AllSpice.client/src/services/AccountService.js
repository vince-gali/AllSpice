import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getAccountRecipes(){
    const res = await api.get('account/recipes')
    logger.log("getting my recipes", res.data)
    AppState.myFavorites = res.data
  }
  
  async getAccountFavorites(){
    const res = await api.get('account/favorites')
    logger.log('Getting Account Favorites',res.data)
  }

}

export const accountService = new AccountService()
