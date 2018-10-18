import React from 'react';
import { View, Text } from 'react-native';
import { colors, metrics } from 'styles';

const Header = ({ title }) => (
  <View
    style={{
      width: "100%",
      justifyContent: 'center',
      backgroundColor: colors.primary,
      paddingHorizontal: metrics.basePadding,
      paddingVertical: metrics.basePadding / 2,
      height: 60,
    }}
  >
    <Text style={{ fontSize: 24, color: colors.secondary, fontWeight: '900' }}>{title}</Text>
  </View>
);

export default Header
