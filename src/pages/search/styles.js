import { StyleSheet } from 'react-native';
import { colors, metrics } from 'styles';

const styles = StyleSheet.create({
  sectionPhoto: {
    width: "20%",
  },
  sectionInfos: {
    justifyContent: 'center',
    paddingHorizontal: metrics.basePadding,
    width: "80%",
  },
  thumbnail: {
    width: 70,
    height: 70,
    borderRadius: 35,
  }
});

export default styles;
