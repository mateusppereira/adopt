import { StyleSheet } from 'react-native';
import { metrics, colors } from 'styles';

const styles = StyleSheet.create({
  section: {
    flex: 1,
    marginVertical: metrics.baseMargin ,
    marginHorizontal: metrics.baseMargin,
    backgroundColor: colors.lighter,
  },
  sectionAnimals: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    borderRadius: metrics.baseRadius,
  },
  sectionDog: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    marginRight: metrics.baseMargin,
    padding: 5,
    borderRadius: metrics.baseRadius,
    backgroundColor: colors.primary,
  },
  sectionCat: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    marginLeft: metrics.baseMargin,
    borderRadius: metrics.baseRadius,
    backgroundColor: colors.primary,
  },
  thumbnail: {
    width: 150,
    height: 150,
  },
  thumbnailDogCat: {
    width: 250,
    height: 150,
  },
});

export default styles;
