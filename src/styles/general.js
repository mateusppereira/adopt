import colors from './colors';
import metrics from './metrics';

export default {
  container: {
    flex: 1,
  },
  row: {
    flexDirection: 'row',
  },
  input: {
    backgroundColor: colors.white,
    borderRadius: metrics.baseRadius,
    height: 44,
    width: '100%',
    marginVertical: metrics.baseMargin,
    elevation: 2,
  },
  box: {
    flexDirection: 'row',
    alignItems: 'center',
    padding: metrics.basePadding,
    backgroundColor: colors.white,
    borderRadius: metrics.baseRadius,
    marginVertical: metrics.baseMargin / 2,
    marginHorizontal: metrics.baseMargin,
    // shadow
    elevation: 4,
    shadowOpacity: 0.75,
    shadowColor: colors.dark,
    shadowRadius: metrics.baseRadius,
    shadowOffset: { height: 0, width: 0 },
    // shadow
  },
  buttonText: {
    fontSize: 16,
    color: colors.white,
  },
  btnFull: {
    backgroundColor: colors.secondary,
    borderRadius: metrics.baseRadius,
    height: 44,
    width: '100%',
    paddingVertical: metrics.basePadding,
    justifyContent: 'center',
    alignItems: 'center',
    elevation: 2,
  },
  itemInfo: {
    flexDirection: 'row',
    marginVertical: metrics.baseMargin / 2,
  },
  itemInfoKey: {
    fontWeight: 'bold',
    fontSize: 14,
    marginHorizontal: metrics.baseMargin / 2,
  },
  itemInfoValue: {
    flex: 1,
  },
};
