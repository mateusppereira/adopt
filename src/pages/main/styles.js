import { StyleSheet } from 'react-native';
import { metrics } from 'styles';

const styles = StyleSheet.create({
  section: {
    flex: 1,
    backgroundColor: colors.danger,
    marginVertical: metrics.baseMargin * 2,
    marginHorizontal: metrics.baseMargin,
  },
  sectionAnimals: {
    flexDirection: 'row',
    justifyContent: 'space-between',
  },
  sectionAnimal: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  }
});

export default styles;
