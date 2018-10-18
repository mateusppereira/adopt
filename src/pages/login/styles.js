import { StyleSheet } from 'react-native';
import { general, colors, metrics } from 'styles';

const styles = StyleSheet.create({
  header: {
    flex: 3,
    alignItems: 'center',
    justifyContent: 'center',
  },
  body: {
    flex: 4,
    backgroundColor: colors.primary,
    justifyContent: 'center',
  },
  textSignup: {
    fontSize: 14,
    color: colors.primary,
    textDecorationLine: 'underline',
    alignSelf: 'flex-end'
  },
  input: {
    ...general.input,
    marginBottom: metrics.baseMargin,
    width: '100%'
  },
  btnEntrar: {
    ...general.btnFull,
    marginVertical: metrics.baseMargin,
    backgroundColor: colors.secondary,
    width: '100%',
  },
});

export default styles;
