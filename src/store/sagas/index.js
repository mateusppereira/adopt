import { takeLatest, all } from 'redux-saga/effects';
import { callSignup } from './signup'
import { callLogin } from './login'
import { get } from './donation'
import { Types as LoginTypes } from 'store/ducks/login'
import { Types as SignupTypes } from 'store/ducks/signup'
import { Types as DonationTypes } from 'store/ducks/donation'

export default function* rootSaga() {
  yield all([
    takeLatest(LoginTypes.CALL_LOGIN, callLogin),
    takeLatest(SignupTypes.CALL_SIGNUP, callSignup),
    takeLatest(DonationTypes.GET, get),
  ])
}